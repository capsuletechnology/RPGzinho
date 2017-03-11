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
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Classe { get; set; }
        public int Vida { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int Slot { get; set; }
    }
}
