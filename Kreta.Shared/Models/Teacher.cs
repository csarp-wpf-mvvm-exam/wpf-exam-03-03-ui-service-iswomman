
namespace Kreta.Shared.Models
{
    public class Teacher : IDbEntity<Teacher>
    {
        public Teacher(Guid id, string firstName, string lastName, DateTime birthsDay)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
        }

        public Teacher(string firstName, string lastName, DateTime birthsDay)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
        }

        public Teacher()
        {
            Id = Guid.NewGuid();
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public bool HasId => Id != Guid.Empty;

        public override string ToString()
        {
            return $"{LastName} {FirstName} - ({String.Format("{0:yyyy.MM.dd.}", BirthsDay)}))";
        }
    }
}
