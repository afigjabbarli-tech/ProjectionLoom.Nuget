using ProjectionLoom.Package;

namespace ProjectionLoom.Test
{
    public class MapperTests
    {
        private readonly Mapper _mapper;

        public MapperTests()
        {
            _mapper = new Mapper();
        }

        [Fact]
        public void Map_Should_Map_Simple_Object()
        {
            // Arrange
            var dto = new { Name = "Afiq", Age = 25 };

            // Act
            var person = _mapper.Map<object, Person>(dto);

            // Assert
            Assert.NotNull(person);
            Assert.Equal("Afiq", person.Name);
            Assert.Equal(25, person.Age);
        }

        [Fact]
        public void Map_Should_Convert_Enum_And_DateTime()
        {
            // Arrange
            var userDto = new UserDto
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = "1995-12-10",
                Status = "Active",
                Roles = new List<string> { "Admin", "Editor" }
            };

            // Act
            var user = _mapper.Map<UserDto, User>(userDto);

            // Assert
            Assert.NotNull(user);
            Assert.Equal("John", user.FirstName);
            Assert.Equal("Doe", user.LastName);
            Assert.Equal(new DateTime(1995, 12, 10), user.BirthDate);
            Assert.Equal(UserStatus.Active, user.Status);
            Assert.Equal(2, user.Roles.Count);
            Assert.Contains("Admin", user.Roles);
        }

        [Fact]
        public void Map_Object_To_Specified_Type()
        {
            // Arrange
            object dto = new { Name = "ProjectionLoom", Age = 1 };

            // Act
            var person = (Person)_mapper.Map(dto, typeof(Person));

            // Assert
            Assert.NotNull(person);
            Assert.Equal("ProjectionLoom", person.Name);
            Assert.Equal(1, person.Age);
        }

        // Helper classes (mirroring ProjectionLoom.Sample)
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class UserDto
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string BirthDate { get; set; }
            public string Status { get; set; }
            public List<string> Roles { get; set; }
        }

        public class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }
            public UserStatus Status { get; set; }
            public List<string> Roles { get; set; }
        }

        public enum UserStatus
        {
            Inactive,
            Active,
            Suspended
        }
    }
}
