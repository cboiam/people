using System.Collections.Generic;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Domain.Entities;

namespace ValidPeople.Infra.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public Task<IEnumerable<Person>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
