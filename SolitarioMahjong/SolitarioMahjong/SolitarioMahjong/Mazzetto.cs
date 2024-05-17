using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitarioMahjong
{
    public class Mazzetto
    {
        private List<Carta> _carteMazzetto;
        
        public List<Carta> CarteMazzetto
        {
            get { return _carteMazzetto; }

        }

        public Mazzetto()
        {
            _carteMazzetto = new List<Carta>();
        }

        public int ContaCarteMazzetto()
        {
            return _carteMazzetto.Count;
        }

        public void AggiungiCarta(Carta carta)
        {
            _carteMazzetto.Add(carta);
        }

        public void RimuoviCarta(Carta carta)
        {
            _carteMazzetto.Remove(carta);
        }

        public Carta UltimaCarta()
        {
            if (_carteMazzetto.Count > 0)
            {
                return _carteMazzetto[_carteMazzetto.Count - 1];
            }
            return null;
        }
    }
}
