using Common.ApiResponseBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model.Model;
using TestProject.Model.ViewModel;
using TestProject.Repository.Context;
using TestProject.Repository.IRepository;
using TestProject.Service.IServices;
using static Common.Enums.Enum;
using Common.ILogging;
using AutoMapper;

namespace TestProject.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo;
        private readonly IUserRepository _userRepo;
        private readonly ApiResponseBuilderDynamic _builderDynamic = new ApiResponseBuilderDynamic();
        private readonly IIogging _logging;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepository accountRepo, IUserRepository userRepo, IIogging logging, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _userRepo = userRepo;
            _logging = logging;
            _mapper = mapper;
        }

        /// <summary>
        /// Create User Account
        /// </summary>
        /// <param name="accountRequest"></param>
        /// <returns>json response of newly created account of user</returns>
        public async Task<TEntityApiDataResponse<AccountResponse>> CreateAccount(AccountRequest accountRequest)
        {
            AccountResponse accountResponse = new AccountResponse();
            try
            {
                var isAccountAlreadyExist = await _accountRepo.ExistAsync(x => x.AccountName.ToLower() == accountRequest.AccountName.ToLower());
                if (isAccountAlreadyExist != null)
                {
                    //saving log details
                    _logging.InsertLogDetails(QbLogType.Info, "AccountService.cs", "CreateAccount()", "Same accout name already exist");
                    return _builderDynamic.ApiResponse((int)EnumApiResponse.Exist, "Same accout name already exist", accountResponse);
                }
                    
                //check user salary and expense
                var userDetail = await _userRepo.GetByIdAsync(accountRequest.UserId); 
                if (userDetail == null)
                {
                    //saving log details
                    _logging.InsertLogDetails(QbLogType.Info, "AccountService.cs", "CreateAccount()", "User not found");
                    return _builderDynamic.ApiResponse((int)EnumApiResponse.NotFound, "User not found", accountResponse);
                }
                    
                decimal balance = userDetail.MonthlySalary - userDetail.MonthlyExpenses;
                if (balance < 1000)
                {
                    //saving log details
                    _logging.InsertLogDetails(QbLogType.Info, "AccountService.cs", "CreateAccount()", "User is not eligible to create account");
                    return _builderDynamic.ApiResponse((int)EnumApiResponse.Failed, "User is not eligible to create account", accountResponse);
                }

                //Mapping Account Request to Account.
                Account account = _mapper.Map<Account>(accountRequest);
                account.CreatedBy = 1;// change after login funtionality add
                account.CreatedDate = DateTime.Now;
                account.IsDeleted = false;

                var result = await _accountRepo.CreateAsync(account);

                //Mapping Account Request to Account Response.
                AccountResponse accResponse = _mapper.Map<AccountResponse>(accountRequest);
                accResponse.UserName = userDetail.Name;
                // saving log details
                _logging.InsertLogDetails(QbLogType.Info, "AccountService.cs", "CreateAccount()", "User account created successfully");
                return _builderDynamic.ApiResponse((int)EnumApiResponse.Success, "User account created successfully", accResponse);
            }
            catch (Exception ex)
            {
                //Saving Error log detail.
                _logging.InsertLogDetails(QbLogType.Error, "AccountService.cs", "CreateAccount()", ex.ToString());
                return _builderDynamic.ApiResponse((int)EnumApiResponse.Failed, ex.Message, accountResponse);
            }
        }

        /// <summary>
        /// Get All Accounts
        /// </summary>
        /// <returns>json response to get all accounts</returns>
        public async Task<TEntityApiDataResponse<IList<AccountResponse>>> GetAccounts()
        {
            try
            {
                var accountList = await _accountRepo.GetAllAsync();

                var result = accountList.Select(x => new AccountResponse { AccountName = x.AccountName, UserName =  _userRepo.GetByIdAsync(x.UserId).Result.Name }).ToList();
                //saving log details
                _logging.InsertLogDetails(QbLogType.Info, "AccountService.cs", "GetAccounts()", "Successfully get all account");
                return _builderDynamic.ApiResponse<IList<AccountResponse>>((int)EnumApiResponse.Success, "Successfully get all account", result);
            }
            catch (Exception ex)
            {
                //Saving Error log detail.
                _logging.InsertLogDetails(QbLogType.Error, "AccountService.cs", "GetAccounts()", ex.ToString());
                return _builderDynamic.ApiResponse<IList<AccountResponse>>((int)EnumApiResponse.Failed, ex.Message, null);
            }
        }
    }
}
