using System;

namespace Kanban.Common
{
    public class BusinessRuleViolationException : Exception
    {
        public BusinessRuleViolationException(string incorrectTaskStatus) :
            base(incorrectTaskStatus)
        {
        }
    }
}
