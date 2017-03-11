using RPGzinho.Model;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGzinho.DAO
{
    public class PersonagemDAO : GenericDAO<Personagem>
    {
        public PersonagemDAO()
        {
            init();
        }

        public List<Personagem> Listar()
        {
            return _conexao.Table<Personagem>().ToList();        
        }
    }
}
