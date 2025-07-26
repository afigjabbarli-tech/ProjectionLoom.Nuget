using ProjectionLoom.Package.Mapping;
using System.Globalization;

namespace ProjectionLoom.Package.Converters
{
    /// <summary>
    /// Handles conversion to <see cref="DateTime"/> and nullable <see cref="DateTime"/> types.
    /// 
    /// Supports conversion from string representations or compatible types to DateTime.
    /// </summary>
    public class DateTimeConverter : ITypeConverter
    {
        /// <summary>
        /// Determines whether this converter can convert to <see cref="DateTime"/> or <see cref="DateTime?"/>.
        /// </summary>
        /// <param name="sourceType">The source type of the value to convert.</param>
        /// <param name="targetType">The target type to convert to.</param>
        /// <returns>
        /// <c>true</c> if the target type is <see cref="DateTime"/> or nullable <see cref="DateTime"/>; otherwise, <c>false</c>.
        /// </returns>
        public bool CanConvert(Type sourceType, Type targetType)
        {
            return targetType == typeof(DateTime) || targetType == typeof(DateTime?);
        }

        /// <summary>
        /// Converts the specified value to the target DateTime type.
        /// </summary>
        /// <param name="value">The value to convert, typically a string or compatible type.</param>
        /// <param name="targetType">The target type, either <see cref="DateTime"/> or nullable <see cref="DateTime"/>.</param>
        /// <returns>The converted DateTime value.</returns>
        public object Convert(object value, Type targetType)
        {
            if (value is string str)
                return DateTime.Parse(str, CultureInfo.InvariantCulture);

            return System.Convert.ChangeType(value, typeof(DateTime));
        }
    }
}
