using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Model.Model;
using TestProject.Repository.Context;
using TestProject.Repository.IRepository;

namespace TestProject.Repository.Repository
{
    public class UserRepository : BaseRepository<User> ,IUserRepository
    {
        public UserRepository(TestDbContext dbContext) : base(dbContext)
        {
                
        }
    }
}
