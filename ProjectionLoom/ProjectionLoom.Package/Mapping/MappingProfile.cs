namespace ProjectionLoom.Package.Mapping
{
    /// <summary>
    /// Represents a configuration profile that stores all registered type converters.
    /// 
    /// A <see cref="MappingProfile"/> acts as a central container for 
    /// <see cref="ITypeConverter"/> implementations, which handle 
    /// custom type conversions during mapping operations.
    /// </summary>
    public class MappingProfile
    {
        /// <summary>
        /// Gets the collection of registered <see cref="ITypeConverter"/> instances.
        /// 
        /// These converters will be used by the mapper to perform type conversions 
        /// between incompatible source and target property types.
        /// </summary>
        public List<ITypeConverter> Converters { get; } = new();

        /// <summary>
        /// Adds a new <see cref="ITypeConverter"/> to the current mapping profile.
        /// </summary>
        /// <param name="converter">The converter instance to add.</param>
        /// <returns>
        /// The current <see cref="MappingProfile"/> instance, allowing method chaining.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="converter"/> is <c>null</c>.
        /// </exception>
        public MappingProfile AddConverter(ITypeConverter converter)
        {
            if (converter == null)
                throw new ArgumentNullException(nameof(converter));

            Converters.Add(converter);
            return this;
        }
    }
}
