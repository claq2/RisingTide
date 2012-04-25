using System;
using System.Collections.Generic;
using System.Linq;

namespace RisingTide.Models
{
    public interface IEntity
    {
        int Id { get; }
        bool IsDeleted { get; set; }
    }
}
