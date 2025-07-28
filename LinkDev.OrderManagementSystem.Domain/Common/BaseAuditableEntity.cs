﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Domain.Common
{
    public abstract class BaseAuditableEntity<TKey> : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedOn { get; set; } /*= DateTime.UtcNow;*/
        public string LastModifiedBy { get; set; } = default!;
        public DateTime LastModifiedOn { get; set; } /*= DateTime.UtcNow;*/

    }
}
