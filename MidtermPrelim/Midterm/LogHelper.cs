using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Midterm
{
    public static class LogHelper
    {
        public static void WriteDebug(string message)
        {
#if LOG
            Logger.Write(message, "Debug");
#endif
        }

        public static void WriteDebug(string message, params object[] args)
        {
#if LOG
            Logger.Write(string.Format(message, args), "Debug");
#endif
        }
    }
}
