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

        public static Personagem CriarPersonagem(string nome, string classe, int slot)
        {
            Personagem personagem = new Personagem();

            if (classe.Equals("Guerreiro"))
            {
                personagem.Nome = nome;
                personagem.Classe = classe;
                personagem.Vida = 125;
                personagem.Forca = 15;
                personagem.Defesa = 0;
                personagem.Level = 1;
                personagem.Exp = 0;
                personagem.Slot = slot;
            }
            else if (classe.Equals("Arqueiro"))
            {
                personagem.Nome = nome;
                personagem.Classe = classe;
                personagem.Vida = 100;
                personagem.Forca = 12;
                personagem.Defesa = 0;
                personagem.Level = 1;
                personagem.Exp = 0;
                personagem.Slot = slot;
            }
            else if (classe.Equals("Mago"))
            {
                personagem.Nome = nome;
                personagem.Classe = classe;
                personagem.Vida = 85;
                personagem.Forca = 8;
                personagem.Defesa = 0;
                personagem.Level = 1;
                personagem.Exp = 0;
                personagem.Slot = slot;
            }

            return personagem;
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
