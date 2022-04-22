using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartSolutions.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registering Routs
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("HomePageView", typeof(HomePageView));
        }
    }
}