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
using RPGzinho.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(CloseApplication))]
namespace RPGzinho.Droid
{
    public class CloseApplication : Helper.ICloseApplication
    {
        public void closeApplication()
        {
            Process.KillProcess(Process.MyPid());
        }
    }
}