using Kreta.Shared.Enums;

namespace Kreta.Shared.Dtos
{
    public class TeacherDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }

        public TeacherDto(Guid id, string firstName, string lastName, DateTime birthsDay)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
        }

        public TeacherDto()
        {
            Id = Guid.NewGuid();
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
        }
    }
}
