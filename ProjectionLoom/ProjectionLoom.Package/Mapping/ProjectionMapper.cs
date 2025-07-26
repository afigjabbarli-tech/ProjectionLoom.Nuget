using ProjectionLoom.Package.Reflection.ProjectionLoom.Reflection;

namespace ProjectionLoom.Package.Mapping
{
    /// <summary>
    /// The primary mapper class that performs object-to-object mapping
    /// using reflection-based techniques.
    /// 
    /// This class implements the <see cref="IMapper"/> interface and delegates
    /// the actual mapping work to the <see cref="ReflectionMapper"/> class.
    /// </summary>
    public class ProjectionMapper : IMapper
    {
        private readonly ReflectionMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectionMapper"/> class,
        /// setting up default type converters and the underlying reflection mapper.
        /// </summary>
        public ProjectionMapper()
        {
            var config = new MappingConfiguration();
            config.AddDefaultConverters();
            _mapper = new ReflectionMapper(config);
        }

        /// <summary>
        /// Maps the specified source object of type <typeparamref name="TSource"/>
        /// to a new instance of type <typeparamref name="TTarget"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source object.</typeparam>
        /// <typeparam name="TTarget">The type of the target object to create.</typeparam>
        /// <param name="source">The source object to map.</param>
        /// <returns>A new instance of <typeparamref name="TTarget"/> with mapped values.</returns>
        public TTarget Map<TSource, TTarget>(TSource source) where TTarget : new()
        {
            return _mapper.Map<TSource, TTarget>(source);
        }

        /// <summary>
        /// Maps the specified source object to a new instance of the given <paramref name="targetType"/>.
        /// </summary>
        /// <param name="source">The source object to map.</param>
        /// <param name="targetType">The target type to map to.</param>
        /// <returns>A new object instance of the specified <paramref name="targetType"/> with mapped values.</returns>
        public object Map(object source, Type targetType)
        {
            return _mapper.Map(source, targetType);
        }
    }
}
