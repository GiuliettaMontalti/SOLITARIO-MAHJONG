using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SolitarioMahjong
{
    public class Mazzo
    {
        private Carta[] _carte;
        private int _indice;

        public Carta[] Carte
        {
            get { return _carte; }

        }

        public int Indice
        {
            get { return _indice; }
            private set
            {
                if (value < 0 || value > _carte.Length)
                {
                    throw new ArgumentOutOfRangeException("indice non accettabile");
                }
                _indice = value;
            }
        }

        public Mazzo()
        {
            _carte = new Carta[40];
            _indice = 0;
            InizializzaMazzo();
        }

        private void InizializzaMazzo()
        {
            int i = 0;
            for (int seme = 1; seme <= 4; seme++)
            {
                for (int valore = 1; valore <= 10; valore++)
                {
                    _carte[i] = new Carta((Valore)valore, (Seme)seme);
                    i++;
                }
            }
        }

        public void MescolaMazzo()
        {
            if (_indice != 0)
            {
                throw new Exception("non puoi mescolare il mazzo se non ha tutte le carte");
            }
            Random random = new Random();
            int pos;
            Carta cartaDaScambiare;
            for (int j = 0; j < 1000; j++)
            {
                for (int i = 0; i < _carte.Length; i++)
                {
                    pos = random.Next(0, _carte.Length);
                    cartaDaScambiare = _carte[pos];
                    _carte[pos] = _carte[i];
                    _carte[i] = cartaDaScambiare;
                }
            }
        }

        public Carta EstraiCarta
        {
            get
            {
                if (_indice >= _carte.Length)
                {
                    throw new Exception("mazzo completamente estratto");
                }
                Carta carta = _carte[_indice];
                _carte[_indice] = null;
                _indice++;
                return carta;
            }
        }

        public Carta VisualizzaCarta
        {
            get
            {
                Carta carta = _carte[_indice];
                return carta;
            }
        }

        public override string ToString()
        {
            string res = "";
            for (int i = _indice; i < _carte.Length; i++)
            {
                res += _carte[i].ToString();
                res += "\n";
            }
            return res;
        }

    }
}
