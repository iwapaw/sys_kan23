using Kanban.Data;
using Kanban.Web.Api.Models;

namespace Kanban.Web.Api.InquiryProcessing
{
    public interface IAllUsersInquiryProcessor
    {
        PagedDataInquiryResponse<User> GetUsers(PagedDataRequest requestInfo);
    }
}
