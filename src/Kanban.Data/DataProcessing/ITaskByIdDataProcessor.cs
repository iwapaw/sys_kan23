using Kanban.Data.Entities;

namespace Kanban.Data.DataProcessing
{
	public interface ITaskByIdDataProcessor
	{
		Task GetTask(long id);
	}
}
