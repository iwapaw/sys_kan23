﻿using Kanban.Common;
using Kanban.Data.Exceptions;
using System.Net;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace Kanban.Web.Common.ErrorHandling
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var exception = context.Exception;

            var httpException = exception as HttpException;
            if (httpException != null)
            {
                context.Result = new SimpleErrorResult(context.Request,
                    (HttpStatusCode)httpException.GetHttpCode(), httpException.Message);
                return;
            }

            if (exception is RootObjectNotFoundException)
            {
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.NotFound,
                    exception.Message);
                return;
            }

            if (exception is ChildObjectNotFoundException)
            {
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.InternalServerError,
                    exception.Message);
                return;
            }

            if (exception is BusinessRuleViolationException)
            {
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.PaymentRequired,
                    exception.Message);
                return;
            }

            context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.InternalServerError,
                    exception.Message);
        }
    }
}
