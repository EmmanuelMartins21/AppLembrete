using AppLembrete.Models;
using AppLembrete.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppLembrete.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCadastrar : ContentPage
    {
        public PageCadastrar()
        {
            InitializeComponent();
        }

        private void btnSalvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                ModelNotas notas = new ModelNotas();
                notas.Titulo = txtTitulo.Text;
                notas.Nota = txtNota.Text;
                notas.Favorito = swFavorito.IsToggled;

                ServicesDbNotas dbNotas = new ServicesDbNotas(App.DbPath); // Necessario passar o caminho do banco
                if (btnSalvar.Text == "Cadastrar")
                {
                    dbNotas.InserirNotas(notas);
                    DisplayAlert($"Operação executada", dbNotas.StatusMessage, "Ok");
                }
                else
                {
                    // alterar uma nota

                }
                MasterDetailPage dP = (MasterDetailPage)Application.Current.MainPage;
                dP.Detail = new PagePrincipal();
            }
            catch(Exception ex)
            {
                DisplayAlert("Erro",ex.Message,"Ok");
            }

        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            MasterDetailPage dP = (MasterDetailPage)Application.Current.MainPage;
            dP.Detail = new PagePrincipal();
        }
    }
}