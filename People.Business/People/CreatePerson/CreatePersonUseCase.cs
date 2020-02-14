using MediatR;
using People.Business.Contacts;
using People.Business.Responses;
using People.Domain.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace People.Business.People.CreatePerson
{
    public class CreatePersonUseCase :
        IRequestHandler<CreatePersonRequest, Person>
    {
        private readonly IRepository _repository;

        public CreatePersonUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Person> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            var fullName = FullName.FromFirstAndLastName(request.FirstName, request.LastName);
            var personDomain = new Domain.Person(fullName, request.HeightInMeters);

            await _repository.Create(personDomain);
            return new Person(personDomain.FullName.FirstName, personDomain.FullName.LastName, personDomain.Height);
        }
    }
}
