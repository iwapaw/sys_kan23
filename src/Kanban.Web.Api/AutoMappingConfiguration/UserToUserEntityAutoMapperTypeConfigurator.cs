
using AutoMapper;
using Kanban.Common.TypeMapping;
using Kanban.Web.Api.Models;

namespace Kanban.Web.Api.AutoMappingConfiguration
{
	public class UserToUserEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<User, Data.Entities.User>()
                .ForMember(opt => opt.Version, x => x.Ignore());
        }
    }
}