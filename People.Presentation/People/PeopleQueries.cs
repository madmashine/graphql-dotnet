using HotChocolate.Types;
using MediatR;
using People.Business.People.GetPerson;
using People.Business.Responses;
using System.Threading.Tasks;

namespace People.Presentation.People
{
    [ExtendObjectType(Name = "Query")]
    public class PeopleQueries
    {
        private readonly IMediator _mediator;

        public PeopleQueries(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Some description test
        /// </summary>
        /// <param name="id">Some parameter description</param>
        /// <returns></returns>
        public async Task<Person> Get(int id)
        {
            var getPersonRequest = new GetPersonRequest();
            var personResponse = await _mediator.Send(getPersonRequest);

            return personResponse;
        }
    }
}
