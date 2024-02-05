namespace Kreta.Shared.Models
{
    public class Parent : IDbEntity<Parent>
    {
        public Parent(Guid id, string firstName, string lastName, DateTime birthsDay)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
        }

        public Parent(string firstName, string lastName, DateTime birthsDay)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
        }

        public Parent()
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
