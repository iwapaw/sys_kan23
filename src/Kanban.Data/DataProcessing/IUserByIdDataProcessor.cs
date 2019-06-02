using Kanban.Data.Entities;

namespace Kanban.Data.DataProcessing
{
	public interface IUserByIdDataProcessor
	{
		User GetUserById(long userId);
	}
}
