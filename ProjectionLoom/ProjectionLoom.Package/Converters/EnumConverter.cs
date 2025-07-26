using ProjectionLoom.Package.Mapping;

namespace ProjectionLoom.Package.Converters
{
    /// <summary>
    /// Handles conversion between enum types and their underlying representations.
    /// 
    /// Supports converting from string or numeric values to enum instances.
    /// </summary>
    public class EnumConverter : ITypeConverter
    {
        /// <summary>
        /// Determines whether this converter can convert to the specified target type.
        /// </summary>
        /// <param name="sourceType">The source type of the value to convert.</param>
        /// <param name="targetType">The target type to convert to.</param>
        /// <returns>
        /// <c>true</c> if the target type is an enum; otherwise, <c>false</c>.
        /// </returns>
        public bool CanConvert(Type sourceType, Type targetType)
        {
            return targetType.IsEnum;
        }

        /// <summary>
        /// Converts the specified value to the target enum type.
        /// </summary>
        /// <param name="value">The value to convert, either string or numeric.</param>
        /// <param name="targetType">The enum type to convert to.</param>
        /// <returns>An instance of the target enum type.</returns>
        public object Convert(object value, Type targetType)
        {
            if (value is string strValue)
                return Enum.Parse(targetType, strValue, ignoreCase: true);

            return Enum.ToObject(targetType, value);
        }
    }
}
