using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitarioMahjong
{
    public class Giocatore
    {
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value == "Inserire nome")
                {
                    throw new ArgumentNullException("nome non valido");
                }
                _nome = value;
            }
        }

        public Giocatore(string nome)
        {
            Nome = nome;
        }
    }
}
