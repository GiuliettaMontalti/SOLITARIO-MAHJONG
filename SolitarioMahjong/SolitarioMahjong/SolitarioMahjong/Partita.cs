using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SolitarioMahjong
{
    public enum Esito
    {
        Vittoria,
        Sconfitta,
        InCorso
    }

    public class Partita
    {
        private Giocatore _giocatore;
        private Mazzo _mazzo;
        private Mazzetto[,] _mazzetti;
        private Esito _esitoPartita;

        public Giocatore Giocatore
        {
            get { return _giocatore; }

        }

        public Mazzo Mazzo
        {
            get { return _mazzo; }

        }

        public Mazzetto[,] Mazzetti
        {
            get { return _mazzetti; }

        }

        public Esito EsitoPartita
        {
            get { return _esitoPartita; }
        }

        public Partita(Giocatore giocatore)
        {
            _giocatore = giocatore;
            _mazzo = new Mazzo();
            _mazzetti = new Mazzetto[4,4];

            InizializzaPartita();
        }

        private void InizializzaPartita()
        {
            _mazzo.MescolaMazzo();
            DistribuisciCarte();
        }

        private void DistribuisciCarte()
        {
            for (int i = 0; i < _mazzetti.GetLength(0); i++)
            {
                for (int j = 0; j < _mazzetti.GetLength(1); j++)
                {
                    if (i == j || (i+j == 3))
                    {
                        _mazzetti[i, j] = new Mazzetto();
                        while (_mazzetti[i, j].CarteMazzetto.Count != 3)
                        {
                            _mazzetti[i, j].AggiungiCarta(_mazzo.EstraiCarta);
                        }
                    }
                    else
                    {
                        _mazzetti[i, j] = new Mazzetto();
                        while (_mazzetti[i, j].CarteMazzetto.Count != 2)
                        {
                            _mazzetti[i, j].AggiungiCarta(_mazzo.EstraiCarta);
                        }
                    }                    
                }
            }
        }

        /// <summary>
        /// restituisce tramite il passaggio per referenza la posizione del mazzetto
        /// </summary>
        /// <param name="numeroRiga"></param>
        /// <param name="numeroColonna"></param>
        /// <param name="mazzetto"></param>
        /// <exception cref="Exception"></exception>
        private void ControllaPosizione(out int numeroRiga, out int numeroColonna, Mazzetto mazzetto)
        {
            bool mazzettoTrovato = false;
            numeroRiga = 0;
            numeroColonna = 0;
            for (int i = 0; i < _mazzetti.GetLength(0); i++)
            {
                for (int j = 0; j < _mazzetti.GetLength(1); j++)
                {
                    if (_mazzetti[i, j].Equals(mazzetto))
                    {
                        mazzettoTrovato = true;
                        numeroRiga = i;
                        numeroColonna = j;
                        break;
                    }
                }
            }
            if (mazzettoTrovato == false)
            {
                throw new Exception("mazzetto non trovato");
            }
        }

        /// <summary>
        /// controlla che il mazzetto utilizzato abbia più carte di uno dei due mazzetti adiacenti
        /// </summary>
        /// <param name="numeroRiga"></param>
        /// <param name="numeroColonna"></param>
        /// <returns></returns>
        private bool ControllaNumeroCarteMazzettiAdiacenti(int numeroRiga, int numeroColonna)
        {
            bool risultato = false;
            if ((_mazzetti[numeroRiga, numeroColonna].ContaCarteMazzetto() > _mazzetti[numeroRiga, numeroColonna+1].ContaCarteMazzetto()) || (_mazzetti[numeroRiga, numeroColonna].ContaCarteMazzetto() > _mazzetti[numeroRiga, numeroColonna -1].ContaCarteMazzetto()))
            {
                risultato = true;
            }
            return risultato;
        }
        
        /// <summary>
        /// verifica che la mossa effettuata sia corretta, controllando se i mazzetti hanno un lato libero e verificando che le carte selezionate abbiano lo stesso valore
        /// </summary>
        /// <param name="mazzetto1"></param>
        /// <param name="mazzetto2"></param>
        /// <returns></returns>
        private bool VerificaCorrettezzaMossa(Mazzetto mazzetto1, Mazzetto mazzetto2)
        {
            bool risultato = false;
            ControllaPosizione(out int numeroRigaMazzetto1, out int numeroColonnaMazzetto1, mazzetto1);
            ControllaPosizione(out int numeroRigaMazzetto2, out int numeroColonnaMazzetto2, mazzetto2);
            if (mazzetto1.UltimaCarta().Equals(mazzetto2.UltimaCarta()))
            {
                if ((numeroColonnaMazzetto1 == 0 || numeroColonnaMazzetto1 == 3) && (numeroColonnaMazzetto2 == 0 || numeroColonnaMazzetto2 == 3))
                {
                    risultato = true;
                }
                else if ((numeroColonnaMazzetto1 == 0 || numeroColonnaMazzetto1 == 3) && ControllaNumeroCarteMazzettiAdiacenti(numeroRigaMazzetto2, numeroColonnaMazzetto2))
                {
                    risultato = true;
                }
                else if ((numeroColonnaMazzetto2 == 0 || numeroColonnaMazzetto2 == 3) && ControllaNumeroCarteMazzettiAdiacenti(numeroRigaMazzetto1, numeroColonnaMazzetto1))
                {
                    risultato = true;
                }
                else if (!((numeroColonnaMazzetto1 == 0 || numeroColonnaMazzetto1 == 3) && (numeroColonnaMazzetto2 == 0 || numeroColonnaMazzetto2 == 3)) && ControllaNumeroCarteMazzettiAdiacenti(numeroRigaMazzetto1, numeroColonnaMazzetto1) && ControllaNumeroCarteMazzettiAdiacenti(numeroRigaMazzetto2, numeroColonnaMazzetto2))
                {
                    risultato = true;
                }        
            }
            
            return risultato;
        }
       
        private void ControllaEsitoPartita()
        {
            bool mazzettiVuoti = true;
            for (int i = 0; i < _mazzetti.GetLength(0); i++)
            {
                for (int j = 0; j < _mazzetti.GetLength(1); j++)
                {
                    if (_mazzetti[i, j].CarteMazzetto.Count != 0)
                    {
                        mazzettiVuoti = false;
                        break;
                    }
                }
            }
            if (mazzettiVuoti)
            {
                _esitoPartita = Esito.Vittoria;
            }
            else if (!VerificaMosseDisponibili())
            {
                _esitoPartita = Esito.Sconfitta;
            }
            else
            {
                _esitoPartita = Esito.InCorso;
            }
        }

        private void RimuoviCartaInAlto(Mazzetto mazzetto1, Mazzetto mazzetto2)
        {            
            if (mazzetto1.ContaCarteMazzetto() > 0)
            {
                mazzetto1.RimuoviCarta(mazzetto1.UltimaCarta());
            }
            if (mazzetto2.ContaCarteMazzetto() > 0)
            {
                mazzetto2.RimuoviCarta(mazzetto2.UltimaCarta());
            }
        }

        private bool VerificaMosseDisponibili()
        {
            bool mosseDisponibili = false;
            Carta carta;
            for (int numeroRigaCartaDaConfrontare = 0; numeroRigaCartaDaConfrontare < _mazzetti.GetLength(0); numeroRigaCartaDaConfrontare++)
            {
                for (int numeroColonnaCartaDaConfrontare = 0; numeroColonnaCartaDaConfrontare < _mazzetti.GetLength(1); numeroColonnaCartaDaConfrontare++)
                {
                    if (_mazzetti[numeroRigaCartaDaConfrontare, numeroColonnaCartaDaConfrontare].ContaCarteMazzetto() > 0)
                    {
                        carta = _mazzetti[numeroRigaCartaDaConfrontare, numeroColonnaCartaDaConfrontare].UltimaCarta();
                        for (int i = 0; i < _mazzetti.GetLength(0); i++)
                        {
                            for (int j = 0; j < _mazzetti.GetLength(1); j++)
                            {
                                if (_mazzetti[i, j].ContaCarteMazzetto() > 0 && _mazzetti[i, j].UltimaCarta().Equals(carta) && _mazzetti[i, j].UltimaCarta().SemeCarta != carta.SemeCarta)
                                {
                                    if (VerificaCorrettezzaMossa(_mazzetti[numeroRigaCartaDaConfrontare, numeroColonnaCartaDaConfrontare], _mazzetti[i, j]))
                                    {
                                        mosseDisponibili = true;
                                        break;
                                    }
                                }
                            }
                            if (mosseDisponibili)
                            {
                                break;
                            }
                        }
                        if (mosseDisponibili)
                        {
                            break;
                        }
                    }     
                }
                if (mosseDisponibili)
                {
                    break;
                }
            }
      
            return mosseDisponibili;
        }

        public void Gioca(Mazzetto mazzetto1, Mazzetto mazzetto2)
        {
            if (mazzetto1 == mazzetto2)
            {
                throw new Exception("non è possibile selezionare due carte dello stesso mazzetto");
            }
            if (VerificaCorrettezzaMossa(mazzetto1, mazzetto2))
            {
                RimuoviCartaInAlto(mazzetto1, mazzetto2);
            }
            else
            {
                throw new Exception("mossa non accettabile");
            }
            ControllaEsitoPartita();
        }
    }
}
