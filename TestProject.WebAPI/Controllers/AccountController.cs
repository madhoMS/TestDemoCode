using Common.ApiResponseBuilder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Model.ViewModel;
using TestProject.Service.IServices;
using TestProject.WebAPI.Validations;

namespace TestProject.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    public class AccountController : ControllerBase
    {

        #region Fields
        private readonly IAccountService _accountService;
        private readonly ApiResponseResult _apiResponseResult = new ApiResponseResult();
        #endregion

        #region Constructor
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        #endregion

        #region Methods

        /// <summary>
        /// This api can create new account for user
        /// </summary>
        /// <param name="model"></param>
        /// <returns>json response of newly created account of user</returns>
        [HttpPost]
        public async  Task<IActionResult> CreateAccount([FromBody] AccountRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _accountService.CreateAccount(model);
            return _apiResponseResult.ResultDataResponse(result);
        }

        /// <summary>
        /// This api useful to get all accounts
        /// </summary>
        /// <returns>json response to get all accounts</returns>
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var result =await  _accountService.GetAccounts();
            return _apiResponseResult.ResultDataResponse(result);
        }
        #endregion
    }
}
