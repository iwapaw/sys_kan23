using Kanban.Data.DataProcessing;
using Kanban.Data.Entities;
using NHibernate;

namespace Kanban.Data.SqlServer.DataProcessing
{
	public class AllUsersDataProcessor : IAllUsersDataProcessor
    {
        private readonly ISession _session;

        public AllUsersDataProcessor(ISession session)
        {
            _session = session;
        }

        public QueryResult<User> GetUsers(PagedDataRequest requestInfo)
        {
            var query = _session.QueryOver<User>();
            var totalItemCount = query.ToRowCountQuery().RowCount();
            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
            var users = query.Skip(startIndex).Take(requestInfo.PageSize).List();
            var queryResult = new QueryResult<User>(users, totalItemCount, requestInfo.PageSize);

            return queryResult;
        }
    }
}
