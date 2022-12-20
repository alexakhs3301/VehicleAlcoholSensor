namespace VehicleAlcoholSensor.Domain.Abstraction
{
    /// <summary>
    /// Base Entity Class
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Entity Identity
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Entity Created Timestamp
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Entity Updated Timestamp
        /// </summary>
        public DateTime UpdatedOn { get; set; }
        /// <summary>
        /// Entity soft deleted value
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
