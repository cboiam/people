using System.Linq;
using ValidPeople.Application.Requests.People;
using ValidPeople.Domain.Entities;
using ValidPeople.Web.Shared;
using ValidPeople.Web.Shared.People;

namespace ValidPeople.UnitTests.Mappings
{
    public static class EntityToRequestMappings
    {
        public static PersonAddRequest MapToAddRequest(this Person person)
        {
            return new PersonAddRequest
            {
                Birth = person.Birth,
                Email = person.Email,
                Name = new NameRequest
                {
                    FirstName = person.Name.FirstName,
                    LastName = person.Name.LastName
                },
                Cpf = new CpfRequest
                {
                    Number = person.Cpf.Number,
                    Emission = person.Cpf.Emission,
                    Expiration = person.Cpf.Expiration
                },
                Parents = person.Parents.Select(parent => new ParentRequest
                {
                    Name = new NameRequest
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

        public static PersonUpdateRequest MapToUpdateRequest(this Person person)
        {
            return new PersonUpdateRequest
            {
                Id = person.Id,
                Birth = person.Birth,
                Email = person.Email,
                Name = new NameRequest
                {
                    FirstName = person.Name.FirstName,
                    LastName = person.Name.LastName
                },
                Cpf = new CpfRequest
                {
                    Number = person.Cpf.Number,
                    Emission = person.Cpf.Emission,
                    Expiration = person.Cpf.Expiration
                },
                Parents = person.Parents.Select(parent => new ParentRequest
                {
                    Name = new NameRequest
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