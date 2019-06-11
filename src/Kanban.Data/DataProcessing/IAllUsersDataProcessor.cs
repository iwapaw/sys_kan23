using Kanban.Data.Entities;

namespace Kanban.Data.DataProcessing
{
    public interface IAllUsersDataProcessor
    {
        QueryResult<User> GetUsers(PagedDataRequest requestInfo);
    }
}
