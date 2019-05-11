using Kanban.Web.Api.Models;
using System.Net.Http;

namespace Kanban.Web.Api.LinkServices
{
    public interface ICommonLinkService
    {
        void AddPageLinks(
            IPageLinkContaining linkContainer, 
            string currentPageQueryString, 
            string previousPageQueryString, 
            string nextPageQueryString
        );

        Link GetLink(string pathFragment, string relValue, HttpMethod httpMethod);
    }
}
