using SimpleTimeTracker.Core.Types;
using System;

namespace SimpleTimeTracker.Core.Models
{
    public class Claim : ModelBase
    {
        public Guid ApplicationUserId { get; set; }
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
