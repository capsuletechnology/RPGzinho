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

        void warriorInfo(object sender, EventArgs e)
        {
            DisplayAlert("Classe Guerreiro", "- Vida: 125\n- Força: 15\n\n- Dano médio.\n- Defesa alta.", "OK");
        }

        void archerInfo(object sender, EventArgs e)
        {
            DisplayAlert("Classe Arqueiro", "- Vida: 100\n- Força: 12\n\n- Dano alto.\n- Defesa média.", "OK");
        }

        void mageInfo(object sender, EventArgs e)
        {
            DisplayAlert("Classe Mago", "- Vida: 85\n- Força: 8\n\n- Dano muito alto.\n- Defesa baixa.", "OK");
        }

        async void ConfirmarWarrior(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Entry1.Text) || String.IsNullOrWhiteSpace(Entry1.Text))
            {
                await DisplayAlert(null, "Digite um nome.", "OK");
                return;
            }
            else
            {
                Model.Personagem personagem;
                personagem = new Model.Personagem(Entry1.Text, "Guerreiro");

                using (var dados = new DAO.PersonagemDAO()) { dados.Insert(personagem); }

                await DisplayAlert(Entry1.Text + " - Guerreiro", "Personagem criado com sucesso!", "OK");
            }
        }

        async void ConfirmarArcher(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Entry2.Text) || String.IsNullOrWhiteSpace(Entry2.Text))
            {
                await DisplayAlert(null, "Digite um nome.", "OK");
                return;
            }
            else
            {
                Model.Personagem personagem;
                personagem = new Model.Personagem(Entry2.Text, "Arqueiro");

                using (var dados = new DAO.PersonagemDAO()) { dados.Insert(personagem); }

                await DisplayAlert(Entry2.Text + " - Arqueiro", "Personagem criado com sucesso!", "OK");
            }
        }

        async void ConfirmarMage(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Entry3.Text) || String.IsNullOrWhiteSpace(Entry3.Text))
            {


                await DisplayAlert(null, "Digite um nome.", "OK");
                return;
            }
            else
            {
                Model.Personagem personagem;
                personagem = new Model.Personagem(Entry3.Text, "Mago");

                using (var dados = new DAO.PersonagemDAO()) { dados.Insert(personagem); }

                await DisplayAlert(Entry3.Text + " - Mago", "Personagem criado com sucesso!", "OK");
            }
        }
    }
}
