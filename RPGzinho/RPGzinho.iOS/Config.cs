using SQLite.Net.Interop;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(RPGzinho.iOS.Config))]
namespace RPGzinho.iOS
{
    public class Config : Services.IConfig
    {
        private string diretorio;
        public string Diretorio
        {
            get
            {
                if (string.IsNullOrEmpty(diretorio))
                {
                    //diretorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    //Para IOS
                    var pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    diretorio = System.IO.Path.Combine(pasta,"..","Library");
                }
                return diretorio;
            }
        }

        private ISQLitePlatform plataforma;
        public ISQLitePlatform Plataforma
        {
            get
            {
                if (plataforma == null)
                {
                    plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }
                return plataforma;
            }
        }
    }
}
