using Bogus;
using Bogus.Extensions.Brazil;
using ValidPeople.Domain.Entities;
using ValidPeople.Domain.Enumerations;

namespace ValidPeople.UnitTests.Fakers.Entities
{
    public static class PersonFaker
    {
        public static Faker<Domain.Entities.Person> Get()
        {
            return new Faker<Domain.Entities.Person>().CustomInstantiator(f => new Domain.Entities.Person(f.Random.Guid(),
                new Name(f.Person.FirstName, f.Person.LastName),
                f.Date.Past(),
                ParentFaker.Get().Generate(2),
                new Cpf(f.Person.Cpf(), f.Date.Future(), f.Date.Past()),
                f.PickRandom(HobbyEnumeration.GetAll()),
                f.Random.Decimal()));
        }
    }
}
