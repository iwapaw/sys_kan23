using Kanban.Common;
using Kanban.Web.Api.InquiryProcessing;
using Kanban.Web.Api.MaintenanceProcessing;
using Kanban.Web.Api.Models;
//using Kanban.Web.Common;
using Kanban.Web.Common.Routing;
using System.Net.Http;
using System.Web.Http;
using Kanban.Web.Common.Validation;
using System.Web.Http.Cors;

namespace Kanban.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("tasks")]
    //[UnitOfWorkActionFilter]
    [Authorize(Roles = Constants.RoleNames.User)]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TasksController : ApiController
    {
        private readonly IAddTaskMaintenanceProcessor _addTaskMaintenanceProcessor;
        private readonly ITaskByIdInquiryProcessor _taskByIdInquiryProcessor;
        private readonly IUpdateTaskMaintenanceProcessor _updateTaskMaintenanceProcessor;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
        private readonly IAllTasksInquiryProcessor _allTasksInquiryProcessor;

        public TasksController(IAddTaskMaintenanceProcessor addTaskMaintenanceProcessor,
            ITaskByIdInquiryProcessor taskByIdInquiryProcessor,
            IUpdateTaskMaintenanceProcessor updateTaskMaintenanceProcessor,
            IPagedDataRequestFactory pagedDataRequestFactory,
            IAllTasksInquiryProcessor allTasksInquiryProcessor)
        {
            _addTaskMaintenanceProcessor = addTaskMaintenanceProcessor;
            _taskByIdInquiryProcessor = taskByIdInquiryProcessor;
            _updateTaskMaintenanceProcessor = updateTaskMaintenanceProcessor;
            _pagedDataRequestFactory = pagedDataRequestFactory;
            _allTasksInquiryProcessor = allTasksInquiryProcessor;
        }

        [Route("", Name = "AddTaskRoute")]
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = Constants.RoleNames.Admin)]
        public IHttpActionResult AddTask(HttpRequestMessage requestMessage, NewTask newTask)
        {
            var task = _addTaskMaintenanceProcessor.AddTask(newTask);
            var result = new TaskCreatedActionResult(requestMessage, task);
            return result;
        }

        [Route("{id:long}", Name = "GetTaskRoute")]
        public Task GetTask(long id)
        {
            var task = _taskByIdInquiryProcessor.GetTask(id);
            return task;
        }

        [Route("", Name = "GetTasksRoute")]
        public PagedDataInquiryResponse<Task> GetTasks(HttpRequestMessage requestMessage)
        {
            var request = _pagedDataRequestFactory.Create(requestMessage.RequestUri);
            var tasks = _allTasksInquiryProcessor.GetTasks(request);
            return tasks;
        }

        [Route("{id:long}", Name = "UpdateTaskRoute")]
        [HttpPut]
        [HttpPatch]
        [ValidateTaskUpdateRequest]
        [Authorize(Roles = Constants.RoleNames.SuperUser)]
        public Task UpdateTask(long id, [FromBody] object updatedTask)
        {
            var task = _updateTaskMaintenanceProcessor.UpdateTask(id, updatedTask);
            return task;
        }
    }
}
