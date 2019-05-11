using System.Collections.Generic;

namespace Kanban.Web.Common
{
    public interface IUpdateablePropertyDetector
    {
        IEnumerable<string> GetNamesOfPropertiesToUpdate<TTargetType>(object objectContainingUpdatedData);
    }
}
