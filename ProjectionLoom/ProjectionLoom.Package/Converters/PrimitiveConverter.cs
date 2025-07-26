using ProjectionLoom.Package.Mapping;

namespace ProjectionLoom.Package.Converters
{

    /// <summary>
    /// Converts primitive types, strings, and decimals between compatible types.
    /// 
    /// This converter handles basic data types using <see cref="System.Convert.ChangeType"/>.
    /// </summary>
    public class PrimitiveConverter : ITypeConverter
    {
        /// <summary>
        /// Determines whether this converter can convert between the specified source and target types.
        /// </summary>
        /// <param name="sourceType">The type of the value to convert from.</param>
        /// <param name="targetType">The type of the value to convert to.</param>
        /// <returns>
        /// <c>true</c> if the target type is a primitive type, string, or decimal; otherwise, <c>false</c>.
        /// </returns>
        public bool CanConvert(Type sourceType, Type targetType)
        {
            return targetType.IsPrimitive || targetType == typeof(string) || targetType == typeof(decimal);
        }

        /// <summary>
        /// Converts the given value to the specified target type.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The target type to convert to.</param>
        /// <returns>The converted value.</returns>
        public object Convert(object value, Type targetType)
        {
            return System.Convert.ChangeType(value, targetType);
        }
    }

}
