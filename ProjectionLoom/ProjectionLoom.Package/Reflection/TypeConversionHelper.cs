using ProjectionLoom.Package.Mapping;

namespace ProjectionLoom.Package.Reflection
{
    /// <summary>
    /// Provides helper methods for converting values between different types,
    /// utilizing a list of registered <see cref="ITypeConverter"/> instances
    /// and fallback conversion logic.
    /// </summary>
    internal static class TypeConversionHelper
    {
        /// <summary>
        /// Attempts to convert the specified <paramref name="value"/> to the given <paramref name="targetType"/>
        /// using the provided list of <paramref name="converters"/>.
        /// </summary>
        /// <param name="value">The source value to convert.</param>
        /// <param name="targetType">The type to convert the value to.</param>
        /// <param name="converters">A list of type converters to try for conversion.</param>
        /// <returns>
        /// The converted value if conversion is successful; otherwise, <c>null</c>.
        /// </returns>
        public static object? ConvertValue(object value, Type targetType, List<ITypeConverter> converters)
        {
            if (value == null) return null;

            foreach (var converter in converters)
            {
                if (converter.CanConvert(value.GetType(), targetType))
                    return converter.Convert(value, targetType);
            }

            try
            {
                if (targetType.IsEnum && value is string enumString)
                    return Enum.Parse(targetType, enumString, true);

                if (Nullable.GetUnderlyingType(targetType) != null)
                    targetType = Nullable.GetUnderlyingType(targetType)!;

                return System.Convert.ChangeType(value, targetType);
            }
            catch
            {
                return null;
            }
        }
    }
}
