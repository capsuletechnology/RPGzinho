using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RPGzinho.View
{
    public partial class NovoPersonagem : ContentPage
    {
        public NovoPersonagem()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            backLayout.BackgroundColor = Color.FromHex("#FFAB00");
            WarriorBtn.BackgroundColor = Color.FromHex("#FFAB00");
            ArcherBtn.BackgroundColor = Color.FromHex("#FFAB00");
            MageBtn.BackgroundColor = Color.FromHex("#FFAB00");
        }

        protected override bool OnBackButtonPressed()
        {
            return Model.Repositorio.SairAplicativo(this);
        }

        async void BackClicked(object sender, EventArgs e)
        {
            await Model.Repositorio.FadeButton(backButton);
            Application.Current.MainPage = new Inicio();
        }

        void WarriorClicked(object sender, EventArgs e)
        {
            Line1.IsVisible = true;
            Line2.IsVisible = false;
            Line3.IsVisible = false;

            archerGrid.IsVisible = false;
            mageGrid.IsVisible = false;
            warriorGrid.IsVisible = true;
        }

        void ArcherClicked(object sender, EventArgs e)
        {
            Line2.IsVisible = true;
            Line1.IsVisible = false;
            Line3.IsVisible = false;

            mageGrid.IsVisible = false;
            warriorGrid.IsVisible = false;
            archerGrid.IsVisible = true;
        }

        void MageClicked(object sender, EventArgs e)
        {
            Line3.IsVisible = true;
            Line1.IsVisible = false;
            Line2.IsVisible = false;

            archerGrid.IsVisible = false;
            warriorGrid.IsVisible = false;
            mageGrid.IsVisible = true;
        }
    }
}
