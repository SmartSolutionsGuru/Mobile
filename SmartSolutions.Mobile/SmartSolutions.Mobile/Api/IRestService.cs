using SmartSolutions.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolutions.Mobile.Api
{
    public interface IRestService
    {
        #region [Methods]
        Task<CompanyInfo> VerifyRegisterdPhoneNumber(string phoneNumber);
        #endregion

        #region [Properties]
         string BaseAddress { get; set;}
        #endregion
    }
}
