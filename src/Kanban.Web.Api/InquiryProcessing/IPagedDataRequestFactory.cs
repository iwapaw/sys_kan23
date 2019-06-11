using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kanban.Data;

namespace Kanban.Web.Api.InquiryProcessing
{
    interface IPagedDataRequestFactory
    {
        PagedDataRequest Create(Uri requestUri);
    }
}
