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

        public PageCadastrar(ModelNotas nota)
        {
            InitializeComponent();
            btnSalvar.Text = "Alterar";
            txtCodigo.IsVisible = true;
            btnExcluir.IsVisible = true;
            txtCodigo.Text = nota.Id.ToString();
            txtTitulo.Text = nota.Titulo;
            txtNota.Text = nota.Nota;
            swFavorito.IsToggled = nota.Favorito;
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
                    notas.Id = Convert.ToInt32(txtCodigo.Text);
                    dbNotas.Atualizar(notas);
                    DisplayAlert($"Operação executada", dbNotas.StatusMessage, "Ok");
                }
                MasterDetailPage dP = (MasterDetailPage)Application.Current.MainPage;
                dP.Detail = new NavigationPage(new PagePrincipal());
            }
            catch(Exception ex)
            {
                DisplayAlert("Erro",ex.Message,"Ok");
            }

        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            MasterDetailPage dP = (MasterDetailPage)Application.Current.MainPage;
            dP.Detail = new NavigationPage(new PagePrincipal());
        }


        private async void btnExcluir_Clicked(object sender, EventArgs e)
        {
            var resp = await DisplayAlert($"Atenção","Deseja realmente excluir este registro?","Sim", "Cancelar");

            if(resp == true)
            {
                ServicesDbNotas dbNotas = new ServicesDbNotas(App.DbPath);
                int id = Convert.ToInt32((txtCodigo.Text));
                dbNotas.RemoverNota(id);
                MasterDetailPage dP = (MasterDetailPage)Application.Current.MainPage;
                dP.Detail = new NavigationPage(new PagePrincipal());
            }
        }
    }
}