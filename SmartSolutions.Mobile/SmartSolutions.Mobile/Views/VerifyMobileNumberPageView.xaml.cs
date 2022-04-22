using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartSolutions.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerifyMobileNumberPageView : ContentPage
    {
        #region [Constructor]
        public VerifyMobileNumberPageView()
        {
            InitializeComponent();
            BindingContext = new ViewModels.VerifyMobileNumberPageViewModel();
            step1.Focus();
            step2.IsEnabled = false;
            step3.IsEnabled = false;
            step4.IsEnabled = false;
        }

        #endregion

        #region [Private Methods]
        private void CustomEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue.Length == 1)
            {
                if(string.IsNullOrEmpty(step2.Text))
                {
                    step2.IsEnabled = true;
                    step2.Focus();
                }
            }
        }
        private void CustomEntry_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1)
            {
                if (string.IsNullOrEmpty(step3.Text))
                {
                    step3.IsEnabled = true;
                    step3.Focus();
                }
            }
            if(e.NewTextValue.Length == 0)
            {
                step2.OnBackspace += EntryBackspaceEventHandler2;
            }
        }
        private void CustomEntry_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1)
            {
                step4.Focus();
                step4.IsEnabled = true;


            }

            if (e.NewTextValue.Length == 0)
            {
                step3.OnBackspace += EntryBackspaceEventHandler3;

            }
        }
        private async void CustomEntry_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 0)
            {
                step4.OnBackspace += EntryBackspaceEventHandler4;
            }
            else 
            {
                //TODO : Replace the Navigation With own Navigation Service
                await Navigation.PushModalAsync(new HomePageView());
            }
        }
        private void EntryBackspaceEventHandler2(object sender, EventArgs e)
        {
            step1.Focus();
            step1.Text = string.Empty;
        }
        private void EntryBackspaceEventHandler3(object sender, EventArgs e)
        {
            step2.Focus();
            step2.Text = string.Empty;
        }
        private void EntryBackspaceEventHandler4(object sender, EventArgs e)
        {
            step3.Focus();
            step3.Text = string.Empty;
        }
        #endregion
    }
}