using Kanban.Common.TypeMapping;
using Kanban.Data.DataProcessing;
using Kanban.Data.Exceptions;
using Kanban.Web.Api.Models;

namespace Kanban.Web.Api.InquiryProcessing
{
    public class TaskByIdInquiryProcessor : ITaskByIdInquiryProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly ITaskByIdDataProcessor _dataProcessor;

        public TaskByIdInquiryProcessor(ITaskByIdDataProcessor dataProcessor, IAutoMapper autoMapper)
        {
            _dataProcessor = dataProcessor;
            _autoMapper = autoMapper;
        }

        public Task GetTask(long taskId)
        {
            var taskEntity = _dataProcessor.GetTask(taskId);

            if (taskEntity == null)
            {
                throw new RootObjectNotFoundException("Task not found");
            }

            var task = _autoMapper.Map<Task>(taskEntity);
            return task;
        }
    }
}