using AutoMapper;
using Kanban.Common.TypeMapping;
using Kanban.Web.Api.Models;

namespace Kanban.Web.Api.AutoMappingConfiguration
{
	public class StatusToStatusEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Status, Data.Entities.Status>()
            .ForMember(opt => opt.Version, x => x.Ignore());
        }
    }
}