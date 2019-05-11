using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Common.Security
{
    public interface IUserSession
    {
        string Firstname { get; }
        string Lastname { get; }
        string Login { get; }
        bool IsInRole(string roleName);
    }
}
