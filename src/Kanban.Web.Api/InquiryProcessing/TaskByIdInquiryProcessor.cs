using Kanban.Common.TypeMapping;
using Kanban.Data.DataProcessing;
using Kanban.Data.Exceptions;
using Kanban.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kanban.Web.Api.InquiryProcessing
{
	public class TaskByIdInquiryProcessor : ITaskByIdInquiryProcessor
	{
		private readonly ITaskByIdDataProcessor _dataProcessor;
		private readonly IAutoMapper _autoMapper;

		public TaskByIdInquiryProcessor(ITaskByIdDataProcessor dataProcessor, IAutoMapper autoMapper)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
		}

		public Task GetTask(long id)
		{
			var taskEntity = _dataProcessor.GetTask(id);

			if (taskEntity == null)
			{
				throw new RootObjectNotFoundException("Task not found");
			}

			var task = _autoMapper.Map<Task>(taskEntity);
			return task;
		}
	}
}