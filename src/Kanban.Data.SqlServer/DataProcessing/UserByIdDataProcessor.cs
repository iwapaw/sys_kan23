using Kanban.Data.DataProcessing;
using Kanban.Data.Entities;
using NHibernate;

namespace Kanban.Data.SqlServer.DataProcessing
{
	public class UserByIdDataProcessor : IUserByIdDataProcessor
	{
		private readonly ISession _session;
		
		public UserByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public User GetUserById(long userId)
		{
			var user = _session.Get<User>(userId);
			return user;
		}
	}
}
