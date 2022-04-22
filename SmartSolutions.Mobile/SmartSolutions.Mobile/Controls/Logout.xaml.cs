using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartSolutions.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Logout : ContentView
    {
        public Logout()
        {
            InitializeComponent();
            this.BindingContext = this;
        }


        public static readonly BindableProperty ShowLogOutProperty =
            BindableProperty.Create(nameof(ShowLogOut),
                                    typeof(bool),
                                    typeof(Logout),
                                    default(bool));

        public bool ShowLogOut
        {
            get { return (bool)GetValue(ShowLogOutProperty); }
            set { SetValue(ShowLogOutProperty, value); }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}