using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Model.Model
{
    public abstract class BaseModel 
    {
        /// <summary>
        /// Get or Set Id
        /// </summary>
        public Int64 Id { get; set; }

        /// <summary>
        /// Get or Set IsDeleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Get or Set CreatedBy
        /// </summary>
        public Int64 CreatedBy { get; set; }
        /// <summary>
        /// Get or Set CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Get or Set ModifiedBy
        /// </summary>
        public Int64 ModifiedBy { get; set; }
        /// <summary>
        /// Get or Set ModifiedDate
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
