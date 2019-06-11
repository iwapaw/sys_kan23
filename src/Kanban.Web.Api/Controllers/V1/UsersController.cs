using Kanban.Common;
using Kanban.Web.Api.InquiryProcessing;
using Kanban.Web.Api.Models;
using Kanban.Web.Common.Routing;
using System.Net.Http;
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
        private readonly IAllUsersInquiryProcessor _allUsersInquiryProcessor;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

        public UsersController(IUserByIdInquiryProcessor userByIdInquiryProcessor, IAllUsersInquiryProcessor allUsersInquiryProcessor)
        {
            _userByIdInquiryProcessor = userByIdInquiryProcessor;
            _allUsersInquiryProcessor = allUsersInquiryProcessor;
            _pagedDataRequestFactory = pagedDataRequestFactory;
        }

        [Route("{id:long}", Name = "GetUserRoute")]
        public User GetUser(long id)
        {
            var user = _userByIdInquiryProcessor.GetUser(id);
            return user;
        }

        public PagedDataInquiryResponse<User> GetUsers(HttpRequestMessage requestMessage)
        {
            var request = _pagedDataRequestFactory.Create(requestMessage.RequestUri);
            var users = _allUsersInquiryProcessor.GetUsers(request);

            return users;
        }
    }
}
