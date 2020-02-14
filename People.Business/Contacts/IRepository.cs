using System.Collections.Generic;
using System.Threading.Tasks;
using People.Domain;

namespace People.Business.Contacts
{
    public interface IRepository
    {
        Task Create(Person domain);
        Task<Person> Get(int id);
        Task<List<Person>> Get();
    }
}