using Kanban.Web.Api.Models;

namespace Kanban.Web.Api.LinkServices
{
    public interface ITaskLinkService
    {
        Link GetAllTasksLink();
        void AddSelfLink(Task task);
        void AddLinksToChildObjects(Task task);
    }
}
