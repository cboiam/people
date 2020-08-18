using ValidPeople.Domain.Enumerations;

namespace ValidPeople.Application.Requests.People
{
    public class ParentRequest
    {
        public NameRequest Name { get; set; }
        public RelationEnumeration Relation { get; set; }
    }
}
