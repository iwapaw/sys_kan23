using AutoMapper;
using Kanban.Common.TypeMapping;
using Kanban.Data.Entities;

namespace Kanban.Web.Api.AutoMappingConfiguration
{
    public class StatusEntityToStatusAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Status, Models.Status>();
        }
    }
}