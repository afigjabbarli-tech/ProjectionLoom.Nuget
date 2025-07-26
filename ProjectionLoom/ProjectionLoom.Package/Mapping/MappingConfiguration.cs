using ProjectionLoom.Package.Converters;
using CollectionConverter = ProjectionLoom.Package.Converters.CollectionConverter;
using DateTimeConverter = ProjectionLoom.Package.Converters.DateTimeConverter;
using EnumConverter = ProjectionLoom.Package.Converters.EnumConverter;

namespace ProjectionLoom.Package.Mapping
{
    /// <summary>
    /// Represents the configuration settings for the mapper, including
    /// the registration of default type converters.
    /// </summary>
    public class MappingConfiguration
    {
        /// <summary>
        /// Gets the <see cref="MappingProfile"/> instance that holds all registered converters.
        /// </summary>
        public MappingProfile Profile { get; } = new();

        /// <summary>
        /// Registers the default set of type converters to the mapping profile.
        /// 
        /// These default converters handle primitive types, enums, DateTime values,
        /// and collection types, enabling the mapper to convert between common data types.
        /// </summary>
        public void AddDefaultConverters()
        {
            Profile.AddConverter(new PrimitiveConverter());
            Profile.AddConverter(new EnumConverter());
            Profile.AddConverter(new DateTimeConverter());
            Profile.AddConverter(new CollectionConverter());
        }
    }
}
