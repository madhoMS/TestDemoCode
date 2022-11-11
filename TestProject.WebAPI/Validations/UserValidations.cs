using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Model.ViewModel;

namespace TestProject.WebAPI.Validations
{
    public class UserValidations : AbstractValidator<UserRequest>
    {
        public UserValidations()
        {
            RuleFor(x => x.EmailAddress).NotEmpty().EmailAddress();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.MonthlySalary).NotEmpty().GreaterThan(0).WithMessage("Please enter a value bigger than 0");
            RuleFor(x => x.MonthlyExpenses).NotEmpty().GreaterThan(0).WithMessage("Please enter a value bigger than 0");
        }
    }
}
