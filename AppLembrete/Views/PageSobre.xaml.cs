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
    public partial class PageSobre : ContentPage
    {
        public PageSobre()
        {
            InitializeComponent();
            
        }
        Image img = new Image
        {
            Source = "Source/images/perfil.jpeg",
            Aspect = Aspect.AspectFit,
            VerticalOptions = LayoutOptions.Fill,
            HorizontalOptions = LayoutOptions.CenterAndExpand,

        };

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            MasterDetailPage dP = (MasterDetailPage)Application.Current.MainPage;
            dP.Detail = new PagePrincipal();
        }
    }
}