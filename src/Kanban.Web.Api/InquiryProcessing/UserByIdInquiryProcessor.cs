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
	public class UserByIdInquiryProcessor : IUserByIdInquiryProcessor
	{
		private readonly IUserByIdDataProcessor _dataProcessor;
		private readonly IAutoMapper _autoMapper;

		public UserByIdInquiryProcessor(IUserByIdDataProcessor dataProcessor, IAutoMapper autoMapper)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
		}

		public User GetUserById(long userId)
		{
			var userEntity = _dataProcessor.GetUserById(userId);

			if (userEntity == null)
			{
				throw new RootObjectNotFoundException("User not found");
			}

			var user = _autoMapper.Map<User>(userEntity);
			return user;
		}
	}
}