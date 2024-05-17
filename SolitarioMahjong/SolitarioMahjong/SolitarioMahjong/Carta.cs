using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitarioMahjong
{
    public enum Valore
    {
        Asso = 1,
        Due,
        Tre,
        Quattro,
        Cinque,
        Sei,
        Sette,
        Otto,
        Nove,
        Dieci
    }

    public enum Seme
    {
        A = 1,
        B,
        C,
        D
    }
    public class Carta
    {
        private Valore _valoreCarta;
        private Seme _semeCarta;
        private string _indirizzoFile;

        public Carta(Valore valoreCarta, Seme semeCarta)
        {
            ValoreCarta = valoreCarta;
            SemeCarta = semeCarta;
            _indirizzoFile = AppContext.BaseDirectory + $"carte/{Convert.ToInt32(ValoreCarta)}" + $"{Convert.ToString(SemeCarta)}.jpg";
        }

        public Valore ValoreCarta
        {
            get { return _valoreCarta; }
            private set
            {
                if ((int)value <= 0 || (int)value > 10)
                {
                    throw new ArgumentException("il valore della carta deve essere compreso tra 1 e 10");
                }
                _valoreCarta = value;
            }
        }

        public Seme SemeCarta
        {
            get { return _semeCarta; }
            private set
            {
                if ((int)value < 1 || (int)value > 4)
                {
                    throw new ArgumentException("seme non valido");
                }
                _semeCarta = value;
            }
        }

        public string IndirizzoFile
        {
            get { return _indirizzoFile; }
        }

        public override bool Equals(object obj)
        {
            bool risultato = false;
            if (obj != null)
            {
                Carta carta = obj as Carta;
                if (carta.ValoreCarta == ValoreCarta)
                {
                    risultato = true;
                }
            }
            return risultato;
        }
    }
}
