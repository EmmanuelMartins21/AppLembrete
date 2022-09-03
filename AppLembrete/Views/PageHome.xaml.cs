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
    public partial class PageHome : ContentPage
    {
        public PageHome()
        {
            InitializeComponent();
            //CarregarLista();
        }
        public void CarregarLista()
        {
            ServicesDbNotas dbNotas = new ServicesDbNotas(App.DbPath);
            var listaInicial = dbNotas.ListarNotas();
            
            if(listaInicial.Count > 0)
            {
                foreach(var item in listaInicial)
                {
                    ListaNotas.ItemsSource = listaInicial;
                }
            }
            //ListaNotas.ItemsSource = dbNotas.ListarNotas();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageCadastrar());
            p.IsPresented = false;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageListar());
            p.IsPresented = false;
        }
    }
}