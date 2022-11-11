using Common.ApiResponseBuilder;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.Model.ViewModel;
using TestProject.Service.IServices;
using TestProject.WebAPI.Controllers;
using Xunit;

namespace TestProject.Tests.Controllers
{
    public class AccountControllerTests
    {
        #region Fields
        private MockRepository mockRepository;
        private Mock<IAccountService> mockAccountService;
        #endregion

        #region Constructer
        public AccountControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockAccountService = this.mockRepository.Create<IAccountService>();
        }
        #endregion

        #region Methods
        private AccountController CreateAccountController()
        {
            return new AccountController(
                this.mockAccountService.Object);
        }
       
        [Fact]
        public void CreateAccount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var accountController = this.CreateAccountController();
            AccountRequest model = new AccountRequest()
            {
                UserId = 1,
                AccountName = "test1"
            };
            
            mockAccountService.Setup(x => x.CreateAccount(model))
             .Returns(GetAccount);

            // Act
            var result = accountController.CreateAccount(
                model);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetAccounts_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var accountList = GetAccounts();
            var accountController = this.CreateAccountController();
            mockAccountService.Setup(x => x.GetAccounts())
               .Returns(GetAccounts);
            // Act
            var result = accountController.GetAccounts();

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        private async Task<TEntityApiDataResponse<IList<AccountResponse>>> GetAccounts()
        {
            ApiResponseBuilderDynamic _builderDynamic = new ApiResponseBuilderDynamic();
            List<AccountResponse> accountList = new List<AccountResponse>
            {
                new AccountResponse
                {
                    AccountName = "testaccount",
                    UserName = "test user1"
                },
                 new AccountResponse
                {
                    AccountName = "testaccount2",
                    UserName = "test user2"
                }
            };
            return _builderDynamic.ApiResponse<IList<AccountResponse>>((int)EnumApiResponse.Success, "Successfully get all accounts", accountList);
        }

        private async Task<TEntityApiDataResponse<AccountResponse>> GetAccount()
        {
            ApiResponseBuilderDynamic _builderDynamic = new ApiResponseBuilderDynamic();
            var account = new AccountResponse() { AccountName = "test1", UserName = "test" };
            return _builderDynamic.ApiResponse<AccountResponse>((int)EnumApiResponse.Success, "User account created successfully", account);
        }

        #endregion
    }
}
