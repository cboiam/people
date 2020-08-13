using System.Collections.Generic;
using System.Linq;
using ValidPeople.Application.Responses.People;
using ValidPeople.Domain.Entities;

namespace ValidPeople.UnitTests.Mappings
{
    public static class EntityToResponseMappings
    {
        public static IEnumerable<PersonListResponse> MapToResponse(this IEnumerable<Person> people)
        {
            return people.Select(person => new PersonListResponse
            {
                Id = person.Id,
                Birth = person.Birth,
                Cpf = person.Cpf.Number,
                Name = person.Name.ToString()
            });
        }

        public static PersonResponse MapToResponse(this Person person)
        {
            return new PersonResponse
            {
                Id = person.Id,
                Birth = person.Birth,
                Name = new NameResponse
                {
                    FirstName = person.Name.FirstName,
                    LastName = person.Name.LastName
                },
                Cpf = new CpfResponse
                {
                    Number = person.Cpf.Number,
                    Emission = person.Cpf.Emission,
                    Expiration = person.Cpf.Expiration
                },
                Parents = person.Parents.Select(parent => new ParentResponse
                {
                    Name = new NameResponse
                    {
                        FirstName = parent.Name.FirstName,
                        LastName = parent.Name.LastName
                    },
                    Relation = parent.Relation
                }),
                Hobby = person.Hobby,
                Revenue = person.Revenue
            };
        }
    }
}
