﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Model.Model
{
    public class User : BaseModel
    {
       
        /// <summary>
        /// Get or Set Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Get or Set EmailAddress
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Get or Set MonthlySalary
        /// </summary>
        public decimal MonthlySalary { get; set; }
        /// <summary>
        /// Get or Set MonthlyExpenses
        /// </summary>
        public decimal MonthlyExpenses { get; set; }
        /// <summary>
        /// Get or Set Password
        /// </summary>
        public string Password { get; set; }
     
    }
}
