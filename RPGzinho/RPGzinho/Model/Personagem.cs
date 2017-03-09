using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGzinho.Model
{
    public class Personagem
    {
        public string Nome { get; set; }
        public string Classe { get; set; }
        public int Vida { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }

        public Personagem(string classe)
        {
            if (classe.Equals("Guerreiro"))
            {
                Classe = classe;
                Forca = 15;
                Defesa = 0;
                Vida = 110;
                Exp = 0;
                Level = 1;

            }
            else if (classe.Equals("Arqueiro"))
            {
                Classe = classe;
                Forca = 12;
                Defesa = 0;
                Vida = 100;
                Exp = 0;
                Level = 1;
            }
            else if (classe.Equals("Bárbaro"))
            {
                Classe = classe;
                Forca = 10;
                Defesa = 0;
                Vida = 125;
                Exp = 0;
                Level = 1;
            }
            else if (classe.Equals("Gatuno"))
            {
                Classe = classe;
                Forca = 10;
                Defesa = 0;
                Vida = 100;
                Exp = 0;
                Level = 1;
            }
            else if (classe.Equals("Mago"))
            {
                Classe = classe;
                Forca = 8;
                Defesa = 0;
                Vida = 85;
                Exp = 0;
                Level = 1;
            }
        }
    }
}
