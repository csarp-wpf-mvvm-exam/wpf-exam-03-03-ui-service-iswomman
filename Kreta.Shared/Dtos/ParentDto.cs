using Kreta.Shared.Enums;

namespace Kreta.Shared.Dtos
{
    public class ParentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }

        public ParentDto(Guid id, string firstName, string lastName, DateTime birthsDay)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
        }

        public ParentDto()
        {
            Id = Guid.NewGuid();
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
        }
    }
}
