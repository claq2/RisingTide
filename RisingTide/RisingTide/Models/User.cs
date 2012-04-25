using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace RisingTide.Models
{
    public class User : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual ICollection<ScheduledPayment> Payments { get; set; }
        public bool IsDeleted { get; set; }
    }
}