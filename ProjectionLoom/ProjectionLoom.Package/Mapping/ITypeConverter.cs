namespace ProjectionLoom.Package.Mapping
{
    /// <summary>
    /// Defines a contract for custom type converters that handle data transformation
    /// between different source and target types.
    /// 
    /// This interface is implemented by all type converter classes
    /// used within the ProjectionLoom library.
    /// </summary>
    public interface ITypeConverter
    {
        /// <summary>
        /// Determines whether this converter can handle conversion
        /// between the specified source and target types.
        /// </summary>
        /// <param name="sourceType">The type of the value to convert from.</param>
        /// <param name="targetType">The type of the value to convert to.</param>
        /// <returns>
        /// <c>true</c> if this converter can perform the conversion;
        /// otherwise, <c>false</c>.
        /// </returns>
        bool CanConvert(Type sourceType, Type targetType);

        /// <summary>
        /// Converts the given value to the specified target type.
        /// 
        /// This method should be called only if <see cref="CanConvert"/> returns <c>true</c>.
        /// </summary>
        /// <param name="value">The source value to convert.</param>
        /// <param name="targetType">The type to convert the value to.</param>
        /// <returns>The converted value.</returns>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion fails or is not supported.
        /// </exception>
        object Convert(object value, Type targetType);
    }
}
