using log4net;
using Kanban.Common;
using Kanban.Common.Logging;
using Kanban.Data.Entities;
using Kanban.Web.Common;
using NHibernate;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;

namespace Kanban.Web.Api.Security
{
    public class BasicSecurityService : IBasicSecurityService
    {
        private readonly ILog _log;

        public BasicSecurityService(ILogManager logManager)
        {
            _log = logManager.GetLog(typeof(BasicSecurityService));
        }

        public virtual ISession Session
        {
            get { return WebContainerManager.Get<ISession>(); }
        }

        public bool SetPrincipal(string Login, string password)
        {
            var user = GetUser(Login);

            IPrincipal principal = null;
            if (user == null || (principal = GetPrincipal(user)) == null)
            {
                _log.DebugFormat("System could not validate user {0}", Login);
                return false;
            }

            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }

            return true;
        }

        public virtual IPrincipal GetPrincipal(User user)
        {
            var identity = new GenericIdentity(user.Login, Constants.SchemeTypes.Basic);

            identity.AddClaim(new Claim(ClaimTypes.GivenName, user.Firstname));
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.Lastname));

            var Login = user.Login.ToLowerInvariant();
            switch (Login)
            {
                case "dbrown":
                    identity.AddClaim(new Claim(ClaimTypes.Role, Constants.RoleNames.Admin));
                    identity.AddClaim(new Claim(ClaimTypes.Role, Constants.RoleNames.SuperUser));
                    identity.AddClaim(new Claim(ClaimTypes.Role, Constants.RoleNames.User));
                    break;
                case "achristie":
                    identity.AddClaim(new Claim(ClaimTypes.Role, Constants.RoleNames.SuperUser));
                    identity.AddClaim(new Claim(ClaimTypes.Role, Constants.RoleNames.User));
                    break;
                case "gmasterton":
                    identity.AddClaim(new Claim(ClaimTypes.Role, Constants.RoleNames.User));
                    break;
                default:
                    return null;
            }

            return new ClaimsPrincipal(identity);
        }

        public virtual User GetUser(string Login)
        {
            Login = Login.ToLowerInvariant();
            return Session.QueryOver<User>().Where(x => x.Login == Login).SingleOrDefault();
        }
    }
}