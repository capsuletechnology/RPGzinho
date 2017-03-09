using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RPGzinho.View
{
    public partial class Principal : ContentPage
    {
        public Principal()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        async void BackClicked(object sender, EventArgs e)
        {            
            await Model.Repositorio.FadeButton(backButton);
            Application.Current.MainPage = new Inicio();
        }
    }
}
