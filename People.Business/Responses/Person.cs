namespace People.Business.Responses
{
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public double Height { get; }

        public Person(string firstName, string lastName, double height)
        {
            FirstName = firstName;
            LastName = lastName;
            Height = height;
        }
    }
}