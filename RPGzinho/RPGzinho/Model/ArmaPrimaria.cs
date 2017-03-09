using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGzinho.Model
{
    public class ArmaPrimaria : Item
    {
        public int Dano { get; set; }
        public int RestricaoLvl { get; set; }
        public string RestricaoClasse { get; set; }
    }
}
