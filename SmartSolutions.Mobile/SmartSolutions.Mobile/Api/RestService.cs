using SmartSolutions.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolutions.Mobile.Api
{
    public class RestService : IRestService
    {
        #region [Private Members]
        private readonly IRequestProvider _requestProvider;
        private readonly string CompanyVerificationAddress = "/api/Companies/GetCompanyByPhone";
        #endregion
        #region [Constructor]
        public RestService()
        {
            //BaseAddress = "https://localhost:7239";
            BaseAddress = "https://192.168.0.218:7239"; 
            _requestProvider = new RequestProvider();
        }
        #endregion
        public async Task<CompanyInfo> VerifyRegisterdPhoneNumber(string phoneNumber)
        {
            var result =  await _requestProvider.GetAsync<CompanyInfo>($"{BaseAddress}{CompanyVerificationAddress}");
            return result;
        }
        public string BaseAddress { get; set; }
    }
}
