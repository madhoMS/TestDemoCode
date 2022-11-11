using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Model.Model;
using TestProject.Model.ViewModel;

namespace TestProject.WebAPI.Validations
{
    public class AccountValidations : AbstractValidator<AccountRequest>
    {
        public AccountValidations()
        {
            RuleFor(p => p.AccountName).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
        }
    }
}
