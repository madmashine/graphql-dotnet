using HotChocolate.Types;
using MediatR;
using People.Business.People.CreatePerson;
using People.Business.Responses;
using System.Threading.Tasks;

namespace People.Presentation.People
{
    [ExtendObjectType(Name = "Mutation")]
    public class PeopleMutations
    {
        private readonly IMediator _mediator;

        public PeopleMutations(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add a person
        /// </summary>
        /// <returns></returns>
        public async Task<Person> Create()
        {
            var createPersonRequest = new CreatePersonRequest("John", "Doe", 1.89);
            var personResponse = await _mediator.Send(createPersonRequest);

            return personResponse;
        }
    }
}
