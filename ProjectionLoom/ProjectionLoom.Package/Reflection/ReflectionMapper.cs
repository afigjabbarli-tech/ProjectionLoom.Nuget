namespace ProjectionLoom.Package.Reflection
{
    using global::ProjectionLoom.Package.Mapping;
    using System.Reflection;

    namespace ProjectionLoom.Reflection
    {
        /// <summary>
        /// Implements the <see cref="IMapper"/> interface using reflection to
        /// map properties from a source object to a target object.
        /// 
        /// This class supports property name matching and uses configured type converters
        /// to handle type mismatches between source and target properties.
        /// </summary>
        public class ReflectionMapper : IMapper
        {
            private readonly MappingConfiguration _config;

            /// <summary>
            /// Initializes a new instance of the <see cref="ReflectionMapper"/> class
            /// with the specified mapping configuration.
            /// </summary>
            /// <param name="config">The mapping configuration containing type converters.</param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="config"/> is <c>null</c>.</exception>
            public ReflectionMapper(MappingConfiguration config)
            {
                _config = config ?? throw new ArgumentNullException(nameof(config));
            }

            /// <summary>
            /// Maps the specified source object of type <typeparamref name="TSource"/>
            /// to a new instance of type <typeparamref name="TTarget"/>.
            /// </summary>
            /// <typeparam name="TSource">The type of the source object.</typeparam>
            /// <typeparam name="TTarget">The type of the target object to create.</typeparam>
            /// <param name="source">The source object to map.</param>
            /// <returns>A new instance of <typeparamref name="TTarget"/> with mapped property values.</returns>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <c>null</c>.</exception>
            public TTarget Map<TSource, TTarget>(TSource source) where TTarget : new()
            {
                if (source == null) throw new ArgumentNullException(nameof(source));
                TTarget target = new();
                MapInternal(source, target);
                return target;
            }

            /// <summary>
            /// Maps the specified source object to a new instance of the given <paramref name="targetType"/>.
            /// </summary>
            /// <param name="source">The source object to map.</param>
            /// <param name="targetType">The target type to map to.</param>
            /// <returns>A new object instance of the specified <paramref name="targetType"/> with mapped property values.</returns>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <c>null</c>.</exception>
            public object Map(object source, Type targetType)
            {
                if (source == null) throw new ArgumentNullException(nameof(source));
                var target = Activator.CreateInstance(targetType)!;
                MapInternal(source, target);
                return target;
            }

            /// <summary>
            /// Internal method that performs property-by-property mapping from the source to the target object.
            /// </summary>
            /// <param name="source">The source object whose properties are read.</param>
            /// <param name="target">The target object whose properties are set.</param>
            private void MapInternal(object source, object target)
            {
                var sourceProps = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var targetProps = target.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var sProp in sourceProps)
                {
                    var tProp = targetProps.FirstOrDefault(p => p.Name == sProp.Name && p.CanWrite);
                    if (tProp == null) continue;

                    object? sValue = sProp.GetValue(source);
                    if (sValue == null) continue;

                    object? converted = TypeConversionHelper.ConvertValue(sValue, tProp.PropertyType, _config.Profile.Converters);
                    if (converted != null)
                        tProp.SetValue(target, converted);
                }
            }
        }
    }

}
