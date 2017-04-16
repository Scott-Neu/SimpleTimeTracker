using SimpleTimeTracker.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleTimeTracker.Core.Models
{
    public abstract class ModelBase
    {
        [Key, Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public DateTime DateEdited { get; set; }
        [Required]
        public Guid UserAdded { get; set; }
        [Required]
        public Guid UserEdited { get; set; }

        public ModelBase()
        { }

        public ModelBase(Guid byUserId)
        {
            Id = SequentialGuid.NewGuid();
            DateAdded = DateTime.UtcNow;
            DateEdited = DateAdded;
            UserAdded = byUserId;
            UserEdited = byUserId;
        }
    }
}