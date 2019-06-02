using Kanban.Common.TypeMapping;
using Kanban.Data.DataProcessing;
using Kanban.Data.Exceptions;
using Kanban.Web.Api.Models;

namespace Kanban.Web.Api.InquiryProcessing
{
    public class UserByIdInquiryProcessor : IUserByIdInquiryProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IUserByIdDataProcessor _dataProcessor;

        public UserByIdInquiryProcessor(IUserByIdDataProcessor dataProcessor, IAutoMapper autoMapper)
        {
            _dataProcessor = dataProcessor;
            _autoMapper = autoMapper;
        }

        public User GetUser(long userId)
        {
            var userEntity = _dataProcessor.GetUser(userId);

            if (userEntity == null)
            {
                throw new RootObjectNotFoundException("User not found");
            }

            var user = _autoMapper.Map<User>(userEntity);
            return user;
        }
    }
}