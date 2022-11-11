using System;
using System.Collections.Generic;
using System.Text;
using static Common.Enums.Enum;

namespace Common.ILogging
{
    public interface IIogging
    {
        bool InsertLogDetails(QbLogType logType, string pageName, string methodName, string note);
    }
}
