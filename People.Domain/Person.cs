using People.Domain.ValueObjects;

namespace People.Domain
{
    public class Person
    {
        public int Id { get; }
        public FullName FullName { get; }
        public double Height { get; }

        public Person(FullName fullName, double height)
        {
            FullName = fullName;
            Height = height;
        }

        public Person(int id, FullName fullName, double height)
            : this(fullName, height)
        {
            Id = id;
        }
    }
}
