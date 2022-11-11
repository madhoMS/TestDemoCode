using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestProject.Model.Model
{
    public class Logs
    {
        /// <summary>
        /// Get or Set Id
        /// </summary>
        [Key]
        public Int64 Id { get; set; }
        /// <summary>
        /// Get or Set LogType
        /// </summary>
        public string LogType { get; set; }
        /// <summary>
        /// Get or Set PageName
        /// </summary>
        public string PageName { get; set; }
        /// <summary>
        /// Get or Set MethodName
        /// </summary>
        public string MethodName { get; set; }
        /// <summary>
        /// Get or Set Note
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Get or Set CreatedOn
        /// </summary>
        public System.DateTime CreatedOn { get; set; }
    }
}
