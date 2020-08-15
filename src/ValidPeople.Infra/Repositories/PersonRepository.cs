using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Domain.Entities;
using ValidPeople.Infra.Interfaces;

namespace ValidPeople.Infra.Repositories
{
    public class PersonRepository : Repository, IPersonRepository
    {
        private readonly IMapper mapper;
        public override string CollectionName => "people";

        public PersonRepository(IFirebaseConnection firebaseConnection, IMapper mapper)
            : base(firebaseConnection)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            var data = await Collection.GetSnapshotAsync();
            var people = data.Select(d => d.ConvertTo<Models.Person>());

            return mapper.Map<IEnumerable<Person>>(people);
        }

        public async Task<Person> Get(Guid id)
        {
            var data = await Collection.WhereEqualTo("Id", id.ToString())
                .GetSnapshotAsync();

            var person = data.FirstOrDefault()?
                .ConvertTo<Models.Person>();

            return mapper.Map<Person>(person);
        }

        public async Task<bool> Delete(Guid id)
        {
            var data = await Collection.WhereEqualTo("Id", id.ToString())
                .GetSnapshotAsync();

            var document = data.FirstOrDefault();

            if (document == null)
            {
                return false;
            }

            var result = await document.Reference.DeleteAsync();
            
            return result != null;
        }
    }
}
