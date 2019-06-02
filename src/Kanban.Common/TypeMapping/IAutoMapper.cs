namespace Kanban.Common.TypeMapping
{
	public interface IAutoMapper
    {
        T Map<T>(object objectToMap);
    }
}
