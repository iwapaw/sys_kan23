using log4net;
using Kanban.Common.Logging;
using System.Web.Http.ExceptionHandling;

namespace Kanban.Web.Common.ErrorHandling
{
    public class SimpleExceptionLogger : ExceptionLogger
    {
        private readonly ILog _log;

        public SimpleExceptionLogger(ILogManager logManager)
        {
            _log = logManager.GetLog(typeof(SimpleExceptionLogger));
        }

        public override void Log(ExceptionLoggerContext context)
        {
            _log.Error("Unhandled exception", context.Exception);
        }
    }
}
