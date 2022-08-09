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
    public partial class PageListar : ContentPage
    {
        public PageListar()
        {
            InitializeComponent();
            AtualizaLista();           
        }
        public void InserirItens()
        {
            ModelNotas nota = new ModelNotas();
            nota.Titulo = "Teste" + DateTime.Now.ToString();
            nota.Nota = "Vamos tentar ";
            nota.Favorito = false;

            ServicesDbNotas dbNotas = new ServicesDbNotas(App.DbPath); // Necessario passar o caminho do banco
            dbNotas.InserirNotas(nota);
            DisplayAlert("", dbNotas.StatusMessage, "Ok");
        }
        public void AtualizaLista()
        {
            ServicesDbNotas dbNotas = new ServicesDbNotas(App.DbPath); // Necessario passar o caminho do banco
            ListaNotas.ItemsSource = dbNotas.ListarNotas();
        }


       /* private void Button_Clicked(object sender, EventArgs e)
        {            
            AtualizaLista();
        }*/

        private void Voltar_Clicked(object sender, EventArgs e)
        {
            MasterDetailPage dP = (MasterDetailPage)Application.Current.MainPage;
            dP.Detail = new PagePrincipal();
        }
       
    }
}