using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RPGzinho.View
{
    public partial class Inicio : ContentPage
    {
        bool Character1 = false;
        bool Character2 = false;

        bool FixFrame1 = false;
        bool FixFrame2 = false;

        public Inicio()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent(); 

            Character1 = true;
            Character2 = false;

            if (Character1) { ImagemRow0.Source = "map.png"; FixFrame1 = false; }               
            else { ImagemRow0.Source = "envelope.png"; FixFrame1 = true; }

            if (Character2) { ImagemRow1.Source = "map.png"; FixFrame2 = false; }
            else { ImagemRow1.Source = "envelope.png"; FixFrame2 = true; }

            if (FixFrame1) { Frame1Layout.Padding = new Thickness(0, 5, 0, 0); }
            if (FixFrame2) { Frame2Layout.Padding = new Thickness(0, 5, 0, 0); }

            Frame1.BackgroundColor = Color.FromRgb(250, 250, 210);
            Frame2.BackgroundColor = Color.FromRgb(250, 250, 210);
        }

        protected override async void OnAppearing()
        {
            await Animation1();
            await Task.WhenAll(
                LogoFade(),
                Titulo.FadeTo(1, 1000, Easing.CubicIn),
                SubGrid.FadeTo(1, 1000, Easing.CubicIn)
            );

            Animation2();
        }

        async Task LogoFade()
        {
            await Logo.FadeTo(0, 500, Easing.CubicIn);
            await Logo.FadeTo(1, 500, Easing.CubicIn);
        }

        async Task Animation1()
        {
            await Task.WhenAll(
                Logo.RotateYTo(360 * 10, 1500, Easing.CubicIn),
                Logo.FadeTo(1, 1500, Easing.CubicIn)
            );
        }

        async void Animation2()
        {
            for (int i = 0; i < 10; i++)
            {
                await Logo.FadeTo(.7, 700);
                await Logo.FadeTo(1, 700);
            }
        }

        async void Imagem0Clicked(object sender, EventArgs e)
        {
            await Model.Repositorio.Fade(ImagemRow0);

            if (Character1)
                Application.Current.MainPage = new Principal();
            else
                Application.Current.MainPage = new NovoPersonagem();
        }

        async void Imagem1Clicked(object sender, EventArgs e)
        {
            await Model.Repositorio.Fade(ImagemRow1);

            if (Character2)
                Application.Current.MainPage = new Principal();
            else
                Application.Current.MainPage = new NovoPersonagem();
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
