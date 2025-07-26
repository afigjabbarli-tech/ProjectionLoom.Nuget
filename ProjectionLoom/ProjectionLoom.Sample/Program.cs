using ProjectionLoom.Package;

namespace ProjectionLoom.Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mapper = new Mapper();

            // 1. Simple object mapping
            var dto = new { Name = "Afiq", Age = 25 };
            var person = mapper.Map<object, Person>(dto);
            Console.WriteLine($"[Simple Mapping] {person.Name} - {person.Age}");

            // 2. Complex object mapping
            var userDto = new UserDto
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = "1995-12-10",
                Status = "Active",
                Roles = new List<string> { "Admin", "Editor" }
            };

            var user = mapper.Map<UserDto, User>(userDto);

            Console.WriteLine("\n[Complex Mapping]");
            Console.WriteLine($"FullName: {user.FirstName} {user.LastName}");
            Console.WriteLine($"BirthDate: {user.BirthDate:yyyy-MM-dd}");
            Console.WriteLine($"Status: {user.Status}");
            Console.WriteLine($"Roles: {string.Join(", ", user.Roles)}");

            // 3. Object -> Type mapping
            object anonymous = new { Name = "ProjectionLoom", Age = 1 };
            var targetPerson = (Person)mapper.Map(anonymous, typeof(Person));
            Console.WriteLine($"\n[Object -> Type] {targetPerson.Name} - {targetPerson.Age}");

            Console.ReadLine();
        }
    }

    /// <summary>
    /// Sample target class used for simple mapping demonstration.
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    /// <summary>
    /// DTO (source object) for a complex mapping example.
    /// </summary>
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; } // Will be mapped to DateTime
        public string Status { get; set; }    // Will be mapped to Enum
        public List<string> Roles { get; set; }
    }

    /// <summary>
    /// Target class with different data types for mapping.
    /// </summary>
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public UserStatus Status { get; set; }
        public List<string> Roles { get; set; }
    }

    /// <summary>
    /// Example enum type for mapping.
    /// </summary>
    public enum UserStatus
    {
        Inactive,
        Active,
        Suspended
    }
}
