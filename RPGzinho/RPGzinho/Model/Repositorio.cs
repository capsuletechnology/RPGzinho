using RPGzinho.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RPGzinho.Model
{
    public class Repositorio
    {
        public async static Task Fade(Image imagem)
        {
            await imagem.FadeTo(.5);
            await imagem.FadeTo(1);
        }

        public async static Task FadeButton(Button button)
        {
            await button.FadeTo(.5);
            await button.FadeTo(1);
        }

        // Impede de fechar o app sem confirmação caso o botão voltar do celular seja pressionado.
        // Usar no método 'protected override bool OnBackButtonPressed()'
        public static bool SairAplicativo(Page page)
        {
            Task<bool> question = page.DisplayAlert("SAIR DO APLICATIVO", "Deseja sair do aplicativo?", "Sim", "Não");
            question.ContinueWith(task =>
            {
                if (task.Result) { DependencyService.Get<ICloseApplication>().closeApplication(); }
            });
            return true;
        }
    }
}
