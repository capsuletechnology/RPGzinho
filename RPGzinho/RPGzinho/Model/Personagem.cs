using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGzinho.Model
{
    [Table("Personagem")]
    public class Personagem
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Classe { get; set; }
        public int Vida { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }

        public Personagem(string nome, string classe)
        {
            if (classe.Equals("Guerreiro"))
            {
                Nome = nome;
                Classe = classe;
                Vida = 125;
                Forca = 15;
                Defesa = 0;
                Level = 1;
                Exp = 0;
            }
            else if (classe.Equals("Arqueiro"))
            {
                Nome = nome;
                Classe = classe;
                Vida = 100;
                Forca = 12;
                Defesa = 0;
                Level = 1;
                Exp = 0;
            }
            else if (classe.Equals("Mago"))
            {
                Nome = nome;
                Classe = classe;
                Vida = 85;
                Forca = 8;
                Defesa = 0;                
                Level = 1;
                Exp = 0;
            }
        }
    }
}
