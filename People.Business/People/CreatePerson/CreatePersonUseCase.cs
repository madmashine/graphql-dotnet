using MediatR;
using People.Business.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace People.Business.People.CreatePerson
{
    public class CreatePersonUseCase :
        IRequestHandler<CreatePersonRequest, Person>
    {
        public Task<Person> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
