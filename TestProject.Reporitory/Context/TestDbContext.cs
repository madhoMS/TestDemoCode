using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Model.Model;

namespace TestProject.Repository.Context
{
   public class TestDbContext :DbContext
    {

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Account { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Logs> logs { get; set; }
    }
}
