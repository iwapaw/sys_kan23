using Kanban.Web.Api.Models;

namespace Kanban.Web.Api.LinkServices
{
    public interface IUserLinkService
    {
        void AddSelfLink(User user);
    }
}
