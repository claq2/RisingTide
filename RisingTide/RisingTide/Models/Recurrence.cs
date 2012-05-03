using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RisingTide.Models
{
    public class Recurrence : IEntity, IEquatable<Recurrence>
    {
        public static readonly string None = "None";
        public static readonly string Weekly = "Weekly";
        public static readonly string Biweekly = "Biweekly";
        public static readonly string Monthly = "Monthly";
        public static readonly string Bimonthly = "Bimonthly";

        public string Name { get; set; }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Recurrence);
        }

        public bool Equals(Recurrence other)
        {
            return (other == null ? false : IsEqualTo(other));
        }

        private bool IsEqualTo(Recurrence other)
        {
            return other == this || this.Name.Equals(other.Name);
        }

        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
