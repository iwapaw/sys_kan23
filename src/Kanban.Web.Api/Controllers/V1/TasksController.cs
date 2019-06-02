using Kanban.Common;
using Kanban.Web.Api.InquiryProcessing;
using Kanban.Web.Api.Models;
using Kanban.Web.Common.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Kanban.Web.Api.Controllers.V1
{
	[ApiVersion1RoutePrefix("tasks")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[Authorize(Roles = Constants.RoleNames.User)]
	public class TasksController : ApiController
	{
		private readonly ITaskByIdInquiryProcessor _taskByIdInquiryProcessor;

		public TasksController(ITaskByIdInquiryProcessor taskByIdInquiryProcessor)
		{
			_taskByIdInquiryProcessor = taskByIdInquiryProcessor;
		}

		[HttpGet]
		[Route("id:long", Name = "GetTaskRoute")]
		public Task GetTask(long id)
		{
			var task = _taskByIdInquiryProcessor.GetTask(id);
			return task;
		}
	}
}