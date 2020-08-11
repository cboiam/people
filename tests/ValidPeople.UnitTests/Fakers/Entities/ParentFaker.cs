using Bogus;
using ValidPeople.Domain.Entities;
using ValidPeople.Domain.Enumerations;

namespace ValidPeople.UnitTests.Fakers.Entities
{
    public class ParentFaker
    {
        public static Faker<Parent> Get()
        {
            return new Faker<Parent>().CustomInstantiator(f => new Parent(new Name(f.Person.FirstName, f.Person.LastName),
                f.PickRandom(RelationEnumeration.GetAll())));
        }
    }
}