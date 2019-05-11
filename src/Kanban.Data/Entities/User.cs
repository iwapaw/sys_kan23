﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Data.Entities
{
    public class User : IVersionedEntity
    {
        public virtual long UserId { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Login { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
