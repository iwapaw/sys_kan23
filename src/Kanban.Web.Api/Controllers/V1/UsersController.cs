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
	[ApiVersion1RoutePrefix("users")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class UsersController : ApiController
	{
		private readonly IUserByIdInquiryProcessor _userByIdInquiryProcessor;

		public UsersController(IUserByIdInquiryProcessor userByIdInquiryProcessor)
		{
			_userByIdInquiryProcessor = userByIdInquiryProcessor;
		}

		[HttpGet]
		[Route("userId:long", Name = "GetUserRoute")]
		public User GetUserById(long userId)
		{
			var user = _userByIdInquiryProcessor.GetUserById(userId);
			return user;
		}
	}
}