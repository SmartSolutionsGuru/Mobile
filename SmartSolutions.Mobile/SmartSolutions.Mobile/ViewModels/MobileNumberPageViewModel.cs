using Acr.UserDialogs;
using SmartSolutions.Mobile.Api;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartSolutions.Mobile.ViewModels
{
    public class MobileNumberPageViewModel : BaseViewModel
    {
        #region [Private Members]
        private readonly IRestService restService;
        #endregion

        #region [Constructor]
        public MobileNumberPageViewModel()
        {
            restService = new RestService();
            SMSCommand = new Command(SnedSMSMessage);
            WhatsAppCommand = new Command(SendWhatsAppMessage);
        }
        #endregion

        #region [Public Methods]
        private async void SendWhatsAppMessage()
        {
            if (!string.IsNullOrEmpty(PhoneNumber))
            {
                UserDialogs.Instance.ShowLoading("Verifying Phone Number", MaskType.Black);
                await VerifyPhoneNumber();
                UserDialogs.Instance.HideLoading();
                await Shell.Current.GoToAsync("//TabPage");
            }
        }

        private async void SnedSMSMessage()
        {
            if (!string.IsNullOrEmpty(PhoneNumber))
            {
                UserDialogs.Instance.ShowLoading("Verifying Phone Number", MaskType.Black);
                await VerifyPhoneNumber();
                UserDialogs.Instance.HideLoading();
                await Shell.Current.GoToAsync("//TabPage");
            }
        }
        #endregion

        #region [Helper Methods]
        private async Task<bool> VerifyPhoneNumber()
        {

            var retVal = false;
            var result = await restService.VerifyRegisterdPhoneNumber(phoneNumber: PhoneNumber);
            if (result != null)
                retVal = true;
            return retVal;
        }
        #endregion

        #region [Properties]
        private string phoneNumber;
        /// <summary>
        /// Registered Phone number Of User
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; NotifyOfPropertyChange(nameof(PhoneNumber)); }
        }
        public Command SMSCommand { get; set; }
        public Command WhatsAppCommand { get; set; }
        #endregion
    }
}
