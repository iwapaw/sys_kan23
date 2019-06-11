using Kanban.Common.TypeMapping;
using Kanban.Data;
using Kanban.Data.DataProcessing;
using Kanban.Data.Exceptions;
using Kanban.Web.Api.LinkServices;
using Kanban.Web.Api.Models;
using System.Collections.Generic;
using System.Linq;
using PagedUserDataInquiryResponse = Kanban.Web.Api.Models.PagedDataInquiryResponse<Kanban.Web.Api.Models.User>;


namespace Kanban.Web.Api.InquiryProcessing
{
    public class AllUsersInquiryProcessor : IAllUsersInquiryProcessor
    {
        public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

        private readonly IAutoMapper _autoMapper;
        private readonly IAllUsersDataProcessor _dataProcessor;
        private readonly ICommonLinkService _commonLinkService;
        private readonly IUserLinkService _userLinkService;

        public AllUsersInquiryProcessor(IAllUsersDataProcessor dataProcessor, IAutoMapper autoMapper, ICommonLinkService commonLinkService, IUserLinkService userLinkService)
        {
            _dataProcessor = dataProcessor;
            _autoMapper = autoMapper;
            _commonLinkService = commonLinkService;
            _userLinkService = userLinkService;
        }

        public PagedUserDataInquiryResponse GetUsers(PagedDataRequest requestInfo)
        {
            var queryResult = _dataProcessor.GetUsers(requestInfo);
            var users = GetUsers(queryResult.QueriedItems).ToList();

            var inquiryResponse = new PagedUserDataInquiryResponse
            {
                Items = users,
                PageCount = queryResult.TotalPageCount,
                PageNumber = requestInfo.PageNumber,
                PageSize = requestInfo.PageSize
            };

            AddLinksToInquiryResponse(inquiryResponse);

            return inquiryResponse;

        }

        public virtual IEnumerable<User> GetUsers(IEnumerable<Data.Entities.User> userEntities)
        {
            var users = userEntities.Select(x => _autoMapper.Map<User>(x)).ToList();

            users.ForEach(x =>
            {
                _userLinkService.AddSelfLink(x);
            });

            return users;
        }

        public virtual void AddLinksToInquiryResponse (PagedUserDataInquiryResponse inquiryResponse)
        {
            //  inquiryResponse.AddLink(_userLinkService.Get)

            _commonLinkService.AddPageLinks(inquiryResponse, GetCurrentPageQueryString(inquiryResponse), GetPreviousPageQueryString(inquiryResponse),
                GetNextPageQueryString(inquiryResponse));
        }

        public virtual string GetCurrentPageQueryString (PagedUserDataInquiryResponse inquiryResponse)
        {
            return string.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
        }

        public virtual string GetPreviousPageQueryString(PagedUserDataInquiryResponse inquiryResponse)
        {
            return string.Format(QueryStringFormat, inquiryResponse.PageNumber -1, inquiryResponse.PageSize);
        }

        public virtual string GetNextPageQueryString(PagedUserDataInquiryResponse inquiryResponse)
        {
            return string.Format(QueryStringFormat, inquiryResponse.PageNumber +1, inquiryResponse.PageSize);
        }
    }
}