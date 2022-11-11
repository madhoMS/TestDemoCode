using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Model.Model
{
    public class Account: BaseModel
    {
        /// <summary>
        /// Get or Set AccountName
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Get or Set UserId
        /// </summary>
        public Int64 UserId { get; set; }
    }
}
