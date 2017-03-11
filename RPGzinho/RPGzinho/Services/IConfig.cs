using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGzinho.Services
{
    public interface IConfig
    {
        string Diretorio { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
