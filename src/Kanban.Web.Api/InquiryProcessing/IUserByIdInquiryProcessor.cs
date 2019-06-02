using Kanban.Web.Api.Models;

namespace Kanban.Web.Api.InquiryProcessing
{
    public interface IUserByIdInquiryProcessor
    {
        User GetUser(long userId);
    }
}
