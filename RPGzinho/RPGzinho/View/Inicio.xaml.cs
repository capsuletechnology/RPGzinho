using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RPGzinho.View
{
    public partial class Inicio : ContentPage
    {
        ObservableCollection<Model.Personagem> ListaPersonagem;
        Model.Personagem personagem1;
        Model.Personagem personagem2;

        bool Character1 = false;
        bool Character2 = false;

        public Inicio()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            GridMaster.IsVisible = false;
            InitializeComponent();            

            //if (FixFrame1) { Frame1Layout.Padding = new Thickness(0, 0, 0, 0); }
            //if (FixFrame2) { Frame2Layout.Padding = new Thickness(0, 0, 0, 0); }

            Frame1.BackgroundColor = Color.FromRgb(250, 250, 210);
            Frame2.BackgroundColor = Color.FromRgb(250, 250, 210);
        }

        protected override async void OnAppearing()
        {
            await Task.WhenAll(
                Logo.RotateYTo(360 * 10, 1000, Easing.CubicIn),
                Logo.FadeTo(1, 1000, Easing.CubicIn),
                Titulo.FadeTo(1, 1500, Easing.CubicIn)
                //SubGrid.FadeTo(1, 1500, Easing.CubicIn)
            );

            Animation2();
        }

        async void Animation2()
        {
            for (int i = 0; i < 10; i++)
            {
                await Logo.FadeTo(.7, 700);
                await Logo.FadeTo(1, 700);
            }
        }

        void Carregar()
        {
            GridMaster.IsVisible = false;

            using (var dados = new DAO.PersonagemDAO())
            {
                ListaPersonagem = new ObservableCollection<Model.Personagem>(dados.Listar());
            }

            foreach (var item in ListaPersonagem)
            {
                if (item.Slot == 1)
                {
                    Character1 = true;
                    personagem1 = item;
                }

                if (item.Slot == 2)
                {
                    Character2 = true;
                    personagem2 = item;
                }
            }

            if (Character1)
            {
                ImagemRow0.Source = "map.png";
                LbNome1.Text = personagem1.Nome;
                LbClasse1.Text = personagem1.Classe;
                LbClasse1.IsVisible = true;
                x1.IsVisible = true;
            }
            else
            {
                LbClasse1.IsVisible = false;
                x1.IsVisible = false;
                ImagemRow0.Source = "letter.png";
                LbNome1.Text = "Toque na carta para começar...";
            }

            if (Character2)
            {
                ImagemRow1.Source = "map.png";
                LbNome2.Text = personagem2.Nome;
                LbClasse2.Text = personagem2.Classe;
                LbClasse2.IsVisible = true;
                x2.IsVisible = true;
            }
            else
            {
                LbClasse2.IsVisible = false;
                x2.IsVisible = false;
                ImagemRow1.Source = "letter.png";
                LbNome2.Text = "Toque na carta para começar...";
            }

            GridMaster.IsVisible = true;
        }

        async void Image1Tapped(object sender, EventArgs e)
        {
            await Model.Repositorio.Fade(ImagemRow0);

            if (Character1)
                Application.Current.MainPage = new Principal();
            else
                Application.Current.MainPage = new NovoPersonagem(1);
        }

        async void Image2Tapped(object sender, EventArgs e)
        {
            await Model.Repositorio.Fade(ImagemRow1);

            if (Character2)
                Application.Current.MainPage = new Principal();
            else
                Application.Current.MainPage = new NovoPersonagem(2);
        }


        async void Excluir1Tapped(object sender, EventArgs e)
        {
            await Model.Repositorio.Fade(x1);

            Task<bool> question = DisplayAlert("DELETAR PERSONAGEM", "Tem certeza que deseja deletar esse personagem?", "Sim", "Não");
            await question.ContinueWith(task =>
            {
                if (task.Result)
                {
                    using (var dados = new DAO.PersonagemDAO())
                    {
                        foreach (var item in dados.Listar())
                        {
                            if (item.Nome.Equals(LbNome1.Text))
                            {
                                dados.Delete(item);
                            }
                        }
                    }
                }
            });

            return;
        }


        async void Excluir2Tapped(object sender, EventArgs e)
        {
            await Model.Repositorio.Fade(x2);

            Task<bool> question = DisplayAlert("DELETAR PERSONAGEM", "Tem certeza que deseja deletar esse personagem?", "Sim", "Não");
            await question.ContinueWith(task =>
            {
                if (task.Result)
                {
                    using (var dados = new DAO.PersonagemDAO())
                    {
                        foreach (var item in dados.Listar())
                        {
                            if (item.Nome.Equals(LbNome2.Text))
                            {
                                dados.Delete(item);
                            }
                        }
                    }
                }
            });
            return;
        }

        //async void TapImagem(object sender, EventArgs e)
        //{
        //    //await Model.Repositorio.Fade(Logo);

        //    //await image.TranslateTo(-100, 0, 1000);    // Move image left
        //    //await image.TranslateTo(-100, -100, 1000); // Move image up
        //    //await image.TranslateTo(100, 100, 2000);   // Move image diagonally down and right
        //    //await image.TranslateTo(0, 100, 1000);     // Move image left
        //    //await image.TranslateTo(0, 0, 1000);       // Move image up

        //    //await Task.Delay(1000);

        //    //await image.TranslateTo(0, 200, 2000, Easing.BounceIn);
        //    //await image.ScaleTo(2, 2000, Easing.CubicIn);
        //    //await image.RotateTo(360, 2000, Easing.SinInOut);
        //    //await image.ScaleTo(1, 2000, Easing.CubicOut);
        //    //await image.TranslateTo(0, -200, 2000, Easing.BounceOut);

        //    // 10 minute animation
        //    //uint duration = 10 * 60 * 1000;
        //    //await Task.WhenAll(
        //    //image.RotateTo(307 * 360, duration),
        //    //image.RotateXTo(251 * 360, duration),
        //    //image.RotateYTo(199 * 360, duration)
        //    //);

        //    //ViewExtensions.CancelAnimations(image);
        //}

        protected override bool OnBackButtonPressed()
        {
            return Model.Repositorio.SairAplicativo(this);
        }
    }
}
