namespace SSToolkit.Domain.Repositories.Model
{
    using System;
    using System.Diagnostics;
    using Newtonsoft.Json;
    using SSToolkit.Fundamental;

    /// <summary>
    /// A base class for all domain entities
    /// </summary>
    [DebuggerDisplay("Type={GetType().Name}, Id={Id}")]
    public abstract class Entity<T> : IEntity<T>
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty(PropertyName = "id")]
        public T Id { get; set; }

        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty(PropertyName = "IId")]
        object IEntity.Id
        {
            get => this.Id;
            set => this.Id = (T)value;
        }


        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">The first object instance</param>
        /// <param name="b">The second object instance</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Id.Equals(b.Id);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">The first object instance</param>
        /// <param name="b">The second object instance</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Entity<T> a, Entity<T> b) => !(a == b);

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var other = obj as Entity<T>;
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => this.GetType().GetHashCode() ^ this.Id.GetHashCode();

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{this.GetType().FullPrettyName()} [Id={this.Id}]";
    }
}
