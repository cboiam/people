using ValidPeople.Domain.Enumerations;

namespace ValidPeople.Application.Responses.People
{
    public class ParentResponse
    {
        public NameResponse Name { get; set; }
        public RelationEnumeration Relation { get; set; }
    }
}
