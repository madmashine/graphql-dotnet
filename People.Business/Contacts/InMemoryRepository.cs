using Bogus;
using People.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Business.Contacts
{
    public class InMemoryRepository :
        IRepository
    {
        private readonly List<Domain.Person> _storage;

        public InMemoryRepository()
        {
            _storage = new List<Domain.Person>();

            for (var id = 1; id < 10; id++)
            {
                var person = new Faker<Domain.Person>()
                    .CustomInstantiator(fake => new Domain.Person(id,
                        FullName.FromFirstAndLastName(fake.Name.FirstName(), fake.Name.LastName()),
                        Math.Round(fake.Random.Double() + 1, 2))).Generate();

                _storage.Add(person);
            }
        }

        public Task Create(Domain.Person domain)
        {
            return Task.Run(() =>
            {
                var id = _storage.Select(entity => entity.Id)
                    .Max();
                id++;

                domain = new Domain.Person(id, domain.FullName, domain.Height);
                _storage.Add(domain);
            });
        }

        public Task<Domain.Person> Get(int id)
        {
            return Task.Run(() =>
            {
                return _storage.SingleOrDefault(entity => entity.Id == id);
            });
        }

        public Task<List<Domain.Person>> Get()
        {
            return Task.Run(() => _storage);
        }
    }
}