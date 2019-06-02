using Kanban.Common;
using Kanban.Web.Api.InquiryProcessing;
using Kanban.Web.Api.Models;
using Kanban.Web.Common.Routing;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Kanban.Web.Api.Controllers.V1
{
	[ApiVersion1RoutePrefix("tasks")]
    [Authorize(Roles = Constants.RoleNames.User)]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TasksController : ApiController
    {
        private readonly ITaskByIdInquiryProcessor _taskByIdInquiryProcessor;

        public TasksController(ITaskByIdInquiryProcessor taskByIdInquiryProcessor)
        {
            _taskByIdInquiryProcessor = taskByIdInquiryProcessor;
        }

        [Route("{id:long}", Name = "GetTaskRoute")]
        public Task GetTask(long id)
        {
            var task = _taskByIdInquiryProcessor.GetTask(id);
            return task;
        }
    }
}
