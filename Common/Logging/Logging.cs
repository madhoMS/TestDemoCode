using Common.ILogging;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Model.Model;
using TestProject.Repository.Context;
using static Common.Enums.Enum;

namespace Common.Logging
{
    public class Logging : IIogging
    {
        private TestDbContext _context;

        public Logging(TestDbContext context)
        {
            _context = context;
        }

        public bool InsertLogDetails(QbLogType logType, string pageName, string methodName, string note)
        {
            try
            {
                Logs logs = new Logs();
                logs.LogType = logType.ToString();
                logs.PageName = pageName;
                logs.MethodName = methodName;
                logs.Note = note;
                logs.CreatedOn = DateTime.Now;
                _context.logs.Add(logs);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
