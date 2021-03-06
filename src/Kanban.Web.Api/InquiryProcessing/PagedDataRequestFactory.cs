﻿using Kanban.Common.Logging;
using Kanban.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Kanban.Common;
using Kanban.Common.Extensions;

namespace Kanban.Web.Api.InquiryProcessing
{
    public class PagedDataRequestFactory : IPagedDataRequestFactory
    {
        public const int DefaultPageSize = 25;
        public const int MaxPageSize = 50;
        private readonly ILog _log;

        public PagedDataRequestFactory(ILogManager logManager)
        {
            _log = logManager.GetLog(typeof(PagedDataRequestFactory));
        }

        public PagedDataRequest Create(Uri requestUri)
        {
            int? pageNumber;
            int? pageSize;

            try
            {
                var valueCollection = requestUri.ParseQueryString();

                pageNumber = PrimitiveTypeParser.Parse<int?>(valueCollection[Constants.CommonParameterNames.PageNumber]);

                pageSize = PrimitiveTypeParser.Parse<int?>(valueCollection[Constants.CommonParameterNames.PageSize]);
            }

            catch (Exception e)
            {
                _log.Error("Error parsing input", e);
                throw new HttpException((int)System.Net.HttpStatusCode.BadRequest, e.Message);
            }

            pageNumber = pageNumber.GetBoundedValue(DefaultPageSize, Constants.Paging.MinPageSize);

            pageSize = pageSize.GetBoundedValue(DefaultPageSize, Constants.Paging.MinPageSize, MaxPageSize);

            return new PagedDataRequest(pageNumber.Value, pageSize.Value);
        }
    }
}