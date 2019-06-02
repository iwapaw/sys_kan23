using AutoMapper;
using Kanban.Common.TypeMapping;
using Kanban.Data.Entities;

namespace Kanban.Web.Api.AutoMappingConfiguration
{
	public class UserEntityToUserAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<User, Models.User>()
                .ForMember(opt => opt.Links, x => x.Ignore());
        }
    }
}