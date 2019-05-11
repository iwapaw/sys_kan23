using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kanban.Data.Entities;

namespace Kanban.Data.SqlServer.Mapping
{
    public class UserMap : VersionedClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.UserId);
            Map(x => x.Firstname).Not.Nullable();
            Map(x => x.Lastname).Not.Nullable();
            Map(x => x.Login).Not.Nullable();
        }
    }
}
