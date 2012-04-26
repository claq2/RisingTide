using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RisingTide.Models
{
    public class PaymentType : IEntity, IEquatable<PaymentType>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as PaymentType);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
        public bool Equals(PaymentType other)
        {
            return (other == null ? false : IsEqualTo(other));
        }

        /// <summary>
        /// Determines whether the current object's reference or Name property is equal to another object's reference or Name property.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// 	<c>true</c> if the current object's reference or Name property is equal to the other parameter; otherwise, <c>false</c>.
        /// </returns>
        private bool IsEqualTo(PaymentType other)
        {
            return other == this || this.Name.Equals(other.Name);
        }

        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
