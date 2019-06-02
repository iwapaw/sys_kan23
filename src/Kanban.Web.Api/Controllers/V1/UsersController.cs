using Kanban.Common;
using Kanban.Web.Api.InquiryProcessing;
using Kanban.Web.Api.Models;
using Kanban.Web.Common;
using Kanban.Web.Common.Routing;
using System.Net.Http;
using System.Web.Http;
using Kanban.Web.Common.Validation;
using System.Web.Http.Cors;

namespace Kanban.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("Users")]
    //[UnitOfWorkActionFilter]
    [Authorize(Roles = Constants.RoleNames.User)]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private readonly IUserByIdInquiryProcessor _userByIdInquiryProcessor;

        public UsersController(IUserByIdInquiryProcessor userByIdInquiryProcessor)
        {
            _userByIdInquiryProcessor = userByIdInquiryProcessor;
        }

        //[Route("", Name = "AddUserRoute")]
        //[HttpPost]
        //[ValidateModel]
        //[Authorize(Roles = Constants.RoleNames.Admin)]
        //public IHttpActionResult AddUser(HttpRequestMessage requestMessage, NewUser newUser)
        //{
        //    var User = _addUserMaintenanceProcessor.AddUser(newUser);
        //    var result = new UserCreatedActionResult(requestMessage, User);
        //    return result;
        //}

        [Route("{id:long}", Name = "GetUserRoute")]
        public User GetUser(long id)
        {
            var user = _userByIdInquiryProcessor.GetUser(id);
            return user;
        }

        //[Route("", Name = "GetUsersRoute")]
        //public PagedDataInquiryResponse<User> GetUsers(HttpRequestMessage requestMessage)
        //{
        //    var request = _pagedDataRequestFactory.Create(requestMessage.RequestUri);
        //    var Users = _allUsersInquiryProcessor.GetUsers(request);
        //    return Users;
        //}

        //[Route("{id:long}", Name = "UpdateUserRoute")]
        //[HttpPut]
        //[HttpPatch]
        //[ValidateUserUpdateRequest]
        //[Authorize(Roles = Constants.RoleNames.SuperUser)]
        //public User UpdateUser(long id, [FromBody] object updatedUser)
        //{
        //    var User = _updateUserMaintenanceProcessor.UpdateUser(id, updatedUser);
        //    return User;
        //}
    }
}
