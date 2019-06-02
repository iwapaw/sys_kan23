using Kanban.Web.Api.Models;

namespace Kanban.Web.Api.InquiryProcessing
{
    public interface ITaskByIdInquiryProcessor
    {
        Task GetTask(long taskId);
    }
}
