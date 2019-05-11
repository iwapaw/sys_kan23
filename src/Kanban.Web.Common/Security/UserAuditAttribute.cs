using log4net;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Threading;
using System.Threading.Tasks;
using Kanban.Common.Logging;
using Kanban.Common.Security;

namespace Kanban.Web.Common.Security
{
    public class UserAuditAttribute : ActionFilterAttribute
    {
        private readonly ILog _log;
        private readonly IUserSession _userSession;

        public UserAuditAttribute()
            : this(WebContainerManager.Get<ILogManager>(), WebContainerManager.Get<IUserSession>())
        {
        }

        public UserAuditAttribute(ILogManager logManager, IUserSession userSession)
        {
            _userSession = userSession;
            _log = logManager.GetLog(typeof(UserAuditAttribute));
        }

        public override bool AllowMultiple
        {
            get { return false; }
        }

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, 
            CancellationToken cancellationToken)
        {
            _log.Debug("Starting execution...");
            var Login = _userSession.Login;
            return Task.Run(() => AuditCurrentUser(Login), cancellationToken);
        }

        public void AuditCurrentUser(string Login)
        {
            // Simulate long auditing process
            _log.InfoFormat("Action being executed by user={0}", Login);
            Thread.Sleep(3000);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            _log.InfoFormat("Action executed by user={0}", _userSession.Login);
        }
    }
}
