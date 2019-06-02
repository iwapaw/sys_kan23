using Kanban.Data.DataProcessing;
using Kanban.Data.Entities;
using NHibernate;

namespace Kanban.Data.SqlServer.DataProcessing
{
	public class TaskByIdDataProcessor : ITaskByIdDataProcessor
	{
		private readonly ISession _session;
		
		public TaskByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public Task GetTask(long id)
		{
			var task = _session.Get<Task>(id);
			return task;
		}
	}
}
