using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using SQLite.Net.Interop;

[assembly: Dependency(typeof(RPGzinho.Droid.Config))]
namespace RPGzinho.Droid
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
                    diretorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    //Para IOS
                    //var pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    //diretorio = System.IO.Path.Combine(pasta, "..", "Library");
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
                    plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return plataforma;
            }
        }
    }
}