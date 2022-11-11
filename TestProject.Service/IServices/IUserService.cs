using Common.ApiResponseBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model.Model;
using TestProject.Model.ViewModel;

namespace TestProject.Service.IServices
{
    public interface IUserService
    {
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns>json response of newy created user</returns>
        Task<TEntityApiDataResponse<UserResponse>> CreateUser(UserRequest request);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>json response of all users</returns>
        Task<TEntityApiDataResponse<IList<UserResponse>>> GetAllUser();

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>json response of selected user</returns>
        Task<TEntityApiDataResponse<UserResponse>> GetUserById(int id);
    }
}
