using AutoMapper;
using Kanban.Common.TypeMapping;
using Kanban.Data.Entities;
using Kanban.Web.Common;
using System.Collections.Generic;
using System.Linq;
using User = Kanban.Web.Api.Models.User;

namespace Kanban.Web.Api.AutoMappingConfiguration
{
	public class TaskAssigneesResolver : ValueResolver<Task, List<User>>
    {
        public IAutoMapper AutoMapper
        {
            get { return WebContainerManager.Get<IAutoMapper>(); }
        }

        protected override List<User> ResolveCore(Task source)
        {
            return source.Users.Select(x => AutoMapper.Map<User>(x)).ToList();
        }
    }
}