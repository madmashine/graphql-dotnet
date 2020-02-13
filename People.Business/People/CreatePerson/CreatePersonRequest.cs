using MediatR;
using People.Business.Responses;

namespace People.Business.People.CreatePerson
{
    public class CreatePersonRequest :
        IRequest<Person>
    {
        public string FirstName { get; }
        public string LastName { get; }

        public CreatePersonRequest(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}