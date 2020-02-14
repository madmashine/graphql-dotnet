using System.Collections.Generic;
using People.Domain.Abstractions;

namespace People.Domain.ValueObjects
{
    public class FullName :
        ValueObject
    {
        public string FirstName { get; }
        public string LastName { get; }

        private FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static FullName FromFirstAndLastName(string firstName, string lastName)
        {
            return new FullName(firstName, lastName);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
