namespace Kanban.Web.Api.Security
{
    public interface IBasicSecurityService
    {
        bool SetPrincipal(string Login, string password);
    }
}
