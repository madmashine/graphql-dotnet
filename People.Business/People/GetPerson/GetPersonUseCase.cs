using MediatR;
using People.Business.Contacts;
using People.Business.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace People.Business.People.GetPerson
{
    public class GetPersonUseCase :
        IRequestHandler<GetPersonRequest, Person>
    {
        private readonly IRepository _repository;

        public GetPersonUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Person> Handle(GetPersonRequest request, CancellationToken cancellationToken)
        {
            var personDomain = await _repository.Get(request.Id);
            return new Person(personDomain.FullName.FirstName, personDomain.FullName.LastName, personDomain.Height);
        }
    }
}
