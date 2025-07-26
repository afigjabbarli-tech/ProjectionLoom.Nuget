namespace ProjectionLoom.Package.Mapping
{
    /// <summary>
    /// Defines a contract for object-to-object mapping operations.
    /// 
    /// All mapper classes in the ProjectionLoom library must implement this interface.
    /// It provides generic and non-generic methods for mapping between different object types.
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// Maps the given <paramref name="source"/> object of type <typeparamref name="TSource"/>
        /// to a new instance of type <typeparamref name="TTarget"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source object.</typeparam>
        /// <typeparam name="TTarget">The type of the target object to create.</typeparam>
        /// <param name="source">The source object to map.</param>
        /// <returns>
        /// A new instance of type <typeparamref name="TTarget"/> with values mapped from the source object.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the <paramref name="source"/> object is <c>null</c>.
        /// </exception>
        TTarget Map<TSource, TTarget>(TSource source)
            where TTarget : new();

        /// <summary>
        /// Maps the given <paramref name="source"/> object to a new instance of the specified <paramref name="targetType"/>.
        /// </summary>
        /// <param name="source">The source object to map.</param>
        /// <param name="targetType">The target type to map to.</param>
        /// <returns>
        /// A new object instance of type <paramref name="targetType"/> with values mapped from the source object.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the <paramref name="source"/> is <c>null</c> or <paramref name="targetType"/> is not specified.
        /// </exception>
        object Map(object source, Type targetType);
    }
}
