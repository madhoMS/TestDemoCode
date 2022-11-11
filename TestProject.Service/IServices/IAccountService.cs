using Common.ApiResponseBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model.ViewModel;

namespace TestProject.Service.IServices
{
    public interface IAccountService
    {
        /// <summary>
        /// Create User Account
        /// </summary>
        /// <param name="accountRequest"></param>
        /// <returns>json response of newly created account of user</returns>
        Task<TEntityApiDataResponse<AccountResponse>>  CreateAccount(AccountRequest accountRequest);

        /// <summary>
        /// Get All Accounts
        /// </summary>
        /// <returns>json response to get all accounts</returns>
        Task<TEntityApiDataResponse<IList<AccountResponse>>> GetAccounts();
    }
}
