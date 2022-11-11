using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Model.Model;
using TestProject.Model.ViewModel;

namespace TestProject.Model.MapperModel
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //Mapping for account
            CreateMap<Account, AccountResponse>();
            CreateMap<AccountRequest, Account>();
            CreateMap<AccountRequest, AccountResponse>();

            //Mapping for User
            CreateMap<UserRequest, UserResponse>();
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();
        }
    }
}
