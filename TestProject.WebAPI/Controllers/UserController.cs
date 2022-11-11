using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Model.Model;
using TestProject.Service.IServices;
using TestProject.Model.ViewModel;
using Common.ApiResponseBuilder;

namespace TestProject.WebAPI.Controllers
{
   
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    public class UserController : Controller
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly ApiResponseResult _apiResponseResult = new ApiResponseResult();
        #endregion

        #region Constructer
        /// <summary>
        /// Constr
        /// </summary>
        /// <param name="service"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Methods

        /// <summary>
        /// This api can create new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns>json response of newy created user</returns>
        /// 
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _userService.CreateUser(request);
            return _apiResponseResult.ResultDataResponse(result);
        }

        /// <summary>
        /// This api can successfully get all user
        /// </summary>
        /// <returns>json response of all users</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var response = await  _userService.GetAllUser();
            return _apiResponseResult.ResultDataResponse(response);
        }

        /// <summary>
        /// This api can get user by its id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>json response of selected user</returns>
        [HttpGet]
        public async Task<IActionResult> GetUserById(int Id)
        {
                var response = await _userService.GetUserById(Id);
                return _apiResponseResult.ResultDataResponse(response);
        }

        #endregion
    }
}
