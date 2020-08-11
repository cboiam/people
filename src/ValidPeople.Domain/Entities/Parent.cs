using ValidPeople.Domain.Enumerations;

namespace ValidPeople.Domain.Entities
{
    public class Parent
    {
        public Name Name { get; private set; }
        public RelationEnumeration Relation { get; private set; }

        public Parent(Name name, RelationEnumeration relation)
        {
            Name = name;
            Relation = relation;
        }
    }
}