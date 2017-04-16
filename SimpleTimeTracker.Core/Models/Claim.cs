using SimpleTimeTracker.Core.Types;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleTimeTracker.Core.Models
{
    public class Claim : ModelBase
    {
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public ClaimType ClaimType { get; set; }

        public Claim()
            : base()
        { }

        public Claim(Guid byUserId, ClaimType claimType)
            : base(byUserId)
        {
            ClaimType = claimType;
        }
    }
}
