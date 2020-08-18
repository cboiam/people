using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidPeople.Domain.Entities;

namespace ValidPeople.Application.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAll();
        Task<Person> Get(Guid id);
        Task<bool> Delete(Guid id);
        Task Post(Person person);
    }
}