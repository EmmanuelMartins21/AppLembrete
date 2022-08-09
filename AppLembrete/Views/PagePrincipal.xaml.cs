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
    public partial class PagePrincipal : MasterDetailPage
    {
        
        public PagePrincipal()
        {
            InitializeComponent();
            //btHome_Clicked(new object(),new EventArgs());
        }
       
        private void btHome_Clicked(object sender, EventArgs e)
        {
            Detail = new PageHome();
            IsPresented = false;
        }

        private void btCadastrar_Clicked(object sender, EventArgs e)
        {
            Detail = new PageCadastrar();
            IsPresented = false;
        }

        private void btListar_Clicked(object sender, EventArgs e)
        {
            Detail = new PageListar();
            IsPresented = false;
        }

        private void btSobre_Clicked(object sender, EventArgs e)
        {
            Detail = new PageSobre();
            IsPresented = false;
        }
    }
}