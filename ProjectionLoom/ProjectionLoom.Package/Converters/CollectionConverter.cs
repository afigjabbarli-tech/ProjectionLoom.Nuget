using ProjectionLoom.Package.Mapping;
using System.Collections;

namespace ProjectionLoom.Package.Converters
{
    /// <summary>
    /// Handles conversion between collection types that implement <see cref="IEnumerable"/>.
    /// 
    /// Supports converting collections such as arrays and generic lists by converting
    /// individual elements to the target collection's element type.
    /// </summary>
    public class CollectionConverter : ITypeConverter
    {
        /// <summary>
        /// Determines whether this converter can convert between the specified
        /// source and target types if both implement <see cref="IEnumerable"/>.
        /// </summary>
        /// <param name="sourceType">The type of the source collection.</param>
        /// <param name="targetType">The type of the target collection.</param>
        /// <returns>
        /// <c>true</c> if both types implement <see cref="IEnumerable"/>; otherwise, <c>false</c>.
        /// </returns>
        public bool CanConvert(Type sourceType, Type targetType)
        {
            return typeof(IEnumerable).IsAssignableFrom(sourceType) && typeof(IEnumerable).IsAssignableFrom(targetType);
        }

        /// <summary>
        /// Converts the elements of the source collection to the target collection type,
        /// converting each element to the target collection's element type.
        /// </summary>
        /// <param name="value">The source collection to convert.</param>
        /// <param name="targetType">The target collection type to convert to.</param>
        /// <returns>
        /// A new instance of the target collection with elements converted to the appropriate type.
        /// </returns>
        public object Convert(object value, Type targetType)
        {
            var elementType = targetType.IsArray
                ? targetType.GetElementType()
                : targetType.GetGenericArguments().FirstOrDefault() ?? typeof(object);

            var list = ((IEnumerable)value).Cast<object>().ToList();
            var convertedList = list.Select(x => System.Convert.ChangeType(x, elementType)).ToArray();

            if (targetType.IsArray)
                return convertedList;

            var genericListType = typeof(List<>).MakeGenericType(elementType);
            return Activator.CreateInstance(genericListType, new object[] { convertedList });
        }
    }
}
