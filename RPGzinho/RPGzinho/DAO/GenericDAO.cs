using RPGzinho.Service;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RPGzinho.DAO
{
    public abstract class GenericDAO<T> : IDisposable
    {
        public SQLite.Net.SQLiteConnection _conexao { get; set; }

        public void init()
        {
            var config = DependencyService.Get<IConfig>();
            _conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.Diretorio, "banco.db3"));
            _conexao.CreateTable<T>();
        }

        public void Insert(T objeto)
        {
            _conexao.InsertWithChildren(objeto);
        }

        public void Update(T objeto)
        {
            _conexao.UpdateWithChildren(objeto);
        }

        public void Delete(T objeto)
        {
            _conexao.Delete(objeto, recursive: true);
        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
