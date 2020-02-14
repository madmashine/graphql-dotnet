using MediatR;
using People.Business.Responses;

namespace People.Business.People.CreatePerson
{
    public class CreatePersonRequest :
        IRequest<Person>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public double HeightInMeters { get; }

        public CreatePersonRequest(string firstName, string lastName, double heightInMeters)
        {
            FirstName = firstName;
            LastName = lastName;
            HeightInMeters = heightInMeters;
        }
    }
}