using ProjectionLoom.Package.Mapping;

namespace ProjectionLoom.Package
{
    /// <summary>
    /// Facade class providing a simple interface for users to perform object mapping.
    /// This class wraps the underlying <see cref="ProjectionMapper"/> and exposes
    /// mapping methods to convert objects between different types.
    /// </summary>
    public class Mapper : IMapper
    {
        private readonly ProjectionMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Mapper"/> class.
        /// </summary>
        public Mapper()
        {
            _mapper = new ProjectionMapper();
        }

        /// <summary>
        /// Maps the specified source object of type <typeparamref name="TSource"/>
        /// to a new instance of type <typeparamref name="TTarget"/>.
        /// </summary>
        public TTarget Map<TSource, TTarget>(TSource source) where TTarget : new()
        {
            return _mapper.Map<TSource, TTarget>(source);
        }

        /// <summary>
        /// Maps the specified source object to a new instance of the given <paramref name="targetType"/>.
        /// </summary>
        public object Map(object source, Type targetType)
        {
            return _mapper.Map(source, targetType);
        }
    }
}
