using RPGzinho.iOS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(CloseApplication))]
namespace RPGzinho.iOS
{
    public class CloseApplication : Helper.ICloseApplication
    {
        public void closeApplication()
        {
            Process.GetCurrentProcess().CloseMainWindow();
            Process.GetCurrentProcess().Close();
        }
    }
}
