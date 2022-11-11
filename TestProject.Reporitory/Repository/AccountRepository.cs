using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Model.Model;
using TestProject.Repository.Context;
using TestProject.Repository.IRepository;

namespace TestProject.Repository.Repository
{
    public class AccountRepository : BaseRepository<Account> ,IAccountRepository
    {
        public AccountRepository(TestDbContext dbContext) : base(dbContext)
        {

        }
    }
}
