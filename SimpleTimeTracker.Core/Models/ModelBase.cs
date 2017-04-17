using SimpleTimeTracker.Extensions;
using System;

namespace SimpleTimeTracker.Core.Models
{
    public abstract class ModelBase
    {
        public Guid Id { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public DateTimeOffset DateEdited { get; set; }
        public Guid UserAddedId { get; set; }
        public Guid UserEditedId { get; set; }
        public bool IsActive { get; set; }

        public ModelBase()
        { }

        public ModelBase(Guid byUserId)
        {
            Id = SequentialGuid.NewGuid();
            DateAdded = DateTimeOffset.UtcNow;
            DateEdited = DateAdded;
            UserAddedId = byUserId;
            UserEditedId = byUserId;
        }
    }
}