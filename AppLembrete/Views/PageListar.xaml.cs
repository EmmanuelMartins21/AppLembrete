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

        public void AtualizaLista()
        {
            ServicesDbNotas dbNotas = new ServicesDbNotas(App.DbPath); // Necessario passar o caminho do banco
            ListaNotas.ItemsSource = dbNotas.ListarNotas();
        }      

        private void Voltar_Clicked(object sender, EventArgs e)
        {
            MasterDetailPage dP = (MasterDetailPage)Application.Current.MainPage;
            dP.Detail = new NavigationPage(new PagePrincipal());
        }

        private void btnExcluir_Clicked(object sender, EventArgs e)
        {
                                                                                 
           //Implemnetar futuramente    
            
        }

        private void ListaNotas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ModelNotas nota = (ModelNotas)ListaNotas.SelectedItem; // captura a seleção da lista
            MasterDetailPage dP = (MasterDetailPage)Application.Current.MainPage;
            dP.Detail = new NavigationPage(new PageCadastrar(nota));

        }
    }
}