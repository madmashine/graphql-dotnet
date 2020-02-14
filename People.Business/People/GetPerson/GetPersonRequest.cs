using MediatR;
using People.Business.Responses;

namespace People.Business.People.GetPerson
{
    public class GetPersonRequest :
        IRequest<Person>
    {
        public int Id { get; }

        public GetPersonRequest(int id)
        {
            Id = id;
        }
    }
}
