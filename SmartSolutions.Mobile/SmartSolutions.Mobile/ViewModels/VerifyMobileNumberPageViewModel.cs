using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartSolutions.Mobile.ViewModels
{
    public class VerifyMobileNumberPageViewModel : BaseViewModel
    {
        #region [Constructor]
        public VerifyMobileNumberPageViewModel()
        {
            PhoneNumber = "923004921550";
        }
        #endregion

        #region [Methods]
        public async Task VerifyOtpNumber()
        {
            try
            {
                //await Shell.Current.GoToAsync();
                
            }
            catch (Exception ex)
            {
                ex.ToString();  
            }
        }
        #endregion

        #region [Properties]
        private string phoneNumber;
        /// <summary>
        /// Phone number Which is Received
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; NotifyOfPropertyChange(nameof(PhoneNumber)); }
        }
        private int? firstDigit;

        public int? FirstDigit
        {
            get { return firstDigit; }
            set { firstDigit = value; NotifyOfPropertyChange(nameof(FirstDigit)); }
        }
        private int? secondDigit;

        public int? SecondDigit
        {
            get { return secondDigit; }
            set { secondDigit = value; NotifyOfPropertyChange(nameof(SecondDigit)); }
        }
        private int? thirdDigit;

        public int? ThirdDigit
        {
            get { return thirdDigit; }
            set { thirdDigit = value; NotifyOfPropertyChange(nameof(ThirdDigit)); }
        }
        private int? forthDigit;

        public int? ForthDigit
        {
            get { return forthDigit; }
            set { forthDigit = value; NotifyOfPropertyChange(nameof(ForthDigit)); }
        }

        #endregion
    }
}
