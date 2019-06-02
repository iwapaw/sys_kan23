using Kanban.Common;
using Kanban.Web.Api.InquiryProcessing;
using Kanban.Web.Api.Models;
using Kanban.Web.Common.Routing;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Kanban.Web.Api.Controllers.V1
{
	[ApiVersion1RoutePrefix("Users")]
    [Authorize(Roles = Constants.RoleNames.User)]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private readonly IUserByIdInquiryProcessor _userByIdInquiryProcessor;

        public UsersController(IUserByIdInquiryProcessor userByIdInquiryProcessor)
        {
            _userByIdInquiryProcessor = userByIdInquiryProcessor;
        }

        [Route("{id:long}", Name = "GetUserRoute")]
        public User GetUser(long id)
        {
            var user = _userByIdInquiryProcessor.GetUser(id);
            return user;
        }
    }
}
