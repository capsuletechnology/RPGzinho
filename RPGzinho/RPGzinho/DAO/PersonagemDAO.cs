using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGzinho.DAO
{
    public class PersonagemDAO : GenericDAO<Model.Personagem>
    {
        public PersonagemDAO()
        {
            init();
        }

        public List<Model.Personagem> Listar()
        {
            return _conexao.GetAllWithChildren<Model.Personagem>();
        }
    }
}
