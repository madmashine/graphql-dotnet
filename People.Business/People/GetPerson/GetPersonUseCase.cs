using MediatR;
using People.Business.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace People.Business.People.GetPerson
{
    public class GetPersonUseCase :
        IRequestHandler<GetPersonRequest, Person>
    {
        public Task<Person> Handle(GetPersonRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() => new Person("John", "Doe", 1.89), cancellationToken);
        }
    }
}
