using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Kanban.Common.TypeMapping;

namespace Kanban.Web.Api.App_Start
{
    public class AutoMapperConfigurator
    {
        public void Configure(IEnumerable<IAutoMapperTypeConfigurator> autoMapperTypeConfigurations)
        {
            autoMapperTypeConfigurations.ToList().ForEach(x => x.Configure());
            Mapper.AssertConfigurationIsValid();
        }
    }
}