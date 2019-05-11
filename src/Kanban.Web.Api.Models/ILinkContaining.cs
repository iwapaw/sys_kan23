using System.Collections.Generic;

namespace Kanban.Web.Api.Models
{
    public interface ILinkContaining
    {
        List<Link> Links { get; set; }
        void AddLink(Link link);
    }
}
