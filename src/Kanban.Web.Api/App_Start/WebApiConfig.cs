using Kanban.Common.Logging;
using Kanban.Web.Common;
using Kanban.Web.Common.ErrorHandling;
using Kanban.Web.Common.Routing;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;
using System.Web.Http.Tracing;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace Kanban.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var constraintsResolver = new DefaultInlineConstraintResolver();

            constraintsResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
            config.MapHttpAttributeRoutes(constraintsResolver);
            config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));
            //config.EnableSystemDiagnosticsTracing(); // replaced by custom writer
            config.Services.Replace(typeof(ITraceWriter), new SimpleTraceWriter(WebContainerManager.Get<ILogManager>()));
            config.Services.Add(typeof(IExceptionLogger),
                new SimpleExceptionLogger(WebContainerManager.Get<ILogManager>()));
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            config.EnableCors();
        }
    }
}
