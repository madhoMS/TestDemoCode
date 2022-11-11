using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model.ViewModel;
using TestProject.Service.IServices;
using TestProject.Model.Model;
using System.Linq;
using Common.ApiResponseBuilder;
using TestProject.Repository.Context;
using TestProject.Repository.IRepository;
using Common.ILogging;
using AutoMapper;
using static Common.Enums.Enum;
using System.Web.Helpers;

namespace TestProject.Service.Service
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly IUserRepository _userRepo;
        private readonly ApiResponseBuilderDynamic _builderDynamic = new ApiResponseBuilderDynamic();
        private readonly IIogging _logging;
        private readonly IMapper _mapper;
        #endregion

        #region Constructer
        public UserService(IUserRepository userRepo, IIogging logging, IMapper mapper)
        {
            _userRepo = userRepo;
            _logging = logging;
            _mapper = mapper;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns>json response of newy created user</returns>
        public async Task<TEntityApiDataResponse<UserResponse>> CreateUser(UserRequest request)
        {
            UserResponse userResponse = new UserResponse();
            try
            {
                var userExist = await _userRepo.ExistAsync(x => x.EmailAddress == request.EmailAddress);
                if(userExist != null)
                {
                    // Mapping User to UserResponse
                    userResponse = _mapper.Map<UserResponse>(userExist);
                    //Saving log detail
                    _logging.InsertLogDetails(QbLogType.Info, "UserService.cs", "CreateUser()", "Email already exist");
                    return _builderDynamic.ApiResponse((int)EnumApiResponse.Success, "Email already exist", userResponse);
                }
                request.Password = request.Password != null ? Crypto.HashPassword(request.Password) : request.Password;
                User user = _mapper.Map<User>(request);
                user.CreatedBy = 1;
                user.CreatedDate = DateTime.Now;
                user.IsDeleted = false;
                await _userRepo.CreateAsync(user);

                // Mapping UserRequest to UserResponse
                userResponse = _mapper.Map<UserResponse>(request);
                //Saving log detail
                _logging.InsertLogDetails(QbLogType.Info, "UserService.cs", "CreateUser()", "User has been created successfully");
                return _builderDynamic.ApiResponse((int)EnumApiResponse.Success,"User has been created successfully", userResponse);
            }
            catch (Exception ex)
            {
                //Saving error log detail
                _logging.InsertLogDetails(QbLogType.Error, "UserService.cs", "CreateUser()", ex.ToString());
                return _builderDynamic.ApiResponse((int)EnumApiResponse.Failed, ex.Message, userResponse);
            }
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>json response of all users</returns>
        public async Task<TEntityApiDataResponse<IList<UserResponse>>> GetAllUser()
        {
            try
            {
                var result = await _userRepo.GetAllAsync();
                
                var response = result.Select(x => new UserResponse { Id = x.Id, Name = x.Name, EmailAddress = x.EmailAddress, MonthlyExpenses = x.MonthlyExpenses,MonthlySalary= x.MonthlySalary}).ToList();
                //Saving log detail
                _logging.InsertLogDetails(QbLogType.Info, "UserService.cs", "GetAllUser()", "Request to get all the user ended successfully.");
                return _builderDynamic.ApiResponse<IList<UserResponse>>((int)EnumApiResponse.Success, "Successfully fetched all the user", response);
            }
            catch (Exception ex)
            {
                //Saving error log detail
                _logging.InsertLogDetails(QbLogType.Error, "UserService.cs", "GetAllUser()", ex.ToString());
                return _builderDynamic.ApiResponse<IList<UserResponse>>((int)EnumApiResponse.Failed, ex.Message, null);
            }
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>json response of selected user</returns>
        public async Task<TEntityApiDataResponse<UserResponse>> GetUserById(int id)
        {
            try
            {
                UserResponse userResponse = new UserResponse();
                var response = await _userRepo.GetByIdAsync(id);
                if(response == null)
                {
                    //Saving log detail
                    _logging.InsertLogDetails(QbLogType.Info, "UserService.cs", "GetUserById()", "user not found.");
                    return _builderDynamic.ApiResponse<UserResponse>((int)EnumApiResponse.NotFound, "user not found", null);
                }

                userResponse = _mapper.Map<UserResponse>(response);
                _logging.InsertLogDetails(QbLogType.Info, "UserService.cs", "GetUserById()", "Successfully get user by id.");
                return _builderDynamic.ApiResponse<UserResponse>((int)EnumApiResponse.Success, "Successfully get user by id", userResponse);
            }
            catch (Exception ex)
            { 
                //Saving error log detail
                _logging.InsertLogDetails(QbLogType.Error, "UserService.cs", "GetUserById()", ex.ToString());
                return _builderDynamic.ApiResponse<UserResponse>((int)EnumApiResponse.Failed, ex.Message, null);
            }
        }
        #endregion
    }
}
