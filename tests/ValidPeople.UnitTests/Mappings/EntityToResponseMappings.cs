using System.Collections.Generic;
using System.Linq;
using ValidPeople.Application.Responses.People;
using ValidPeople.Domain.Entities;
using ValidPeople.Web.Shared;
using ValidPeople.Web.Shared.People;

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
                Email = person.Email,
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
                Email = person.Email,
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
                Revenue = person.Revenue,
                Profession = person.Profession,
                EducationalLevel = person.EducationalLevel,
                Status = person.Status,
                Cloned = person.Cloned
            };
        }

        public static IEnumerable<PersonListViewModel> MapToViewModel(this IEnumerable<Person> people)
        {
            return people.Select(person => new PersonListViewModel
            {
                Id = person.Id,
                Birth = person.Birth,
                Email = person.Email,
                Cpf = person.Cpf.Number,
                Name = person.Name.ToString()
            });
        }

        public static PersonViewModel MapToViewModel(this Person person)
        {
            return new PersonViewModel
            {
                Id = person.Id,
                Birth = person.Birth,
                Email = person.Email,
                Name = new NameViewModel
                {
                    FirstName = person.Name.FirstName,
                    LastName = person.Name.LastName
                },
                Cpf = new CpfViewModel
                {
                    Number = person.Cpf.Number,
                    Emission = person.Cpf.Emission,
                    Expiration = person.Cpf.Expiration
                },
                Parents = person.Parents.Select(parent => new ParentViewModel
                {
                    Name = new NameViewModel
                    {
                        FirstName = parent.Name.FirstName,
                        LastName = parent.Name.LastName
                    },
                    Relation = new EnumerationViewModel
                    {
                        Id = parent.Relation.Id,
                        Name = parent.Relation.Name
                    }
                }).ToList(),
                Hobby = new EnumerationViewModel
                {
                    Id = person.Hobby.Id,
                    Name = person.Hobby.Name
                },
                Revenue = person.Revenue,
                Profession = person.Profession,
                EducationalLevel = new EnumerationViewModel{
                    Id = person.EducationalLevel.Id,
                    Name = person.EducationalLevel.Name
                },
                Status = new EnumerationViewModel{
                    Id = person.Status.Id,
                    Name = person.Status.Name
                },
                Cloned = person.Cloned
            };
        }
    }
}