using System.Collections.Generic;

namespace ValidPeople.Domain.Enumerations
{
    public class RelationEnumeration : Enumeration
    {

        public RelationEnumeration() { 
        }
        public RelationEnumeration(int id, string name) 
            : base(id, name) { }

        public static RelationEnumeration Father = new RelationEnumeration(1, "Father");
        public static RelationEnumeration Mother = new RelationEnumeration(2, "Mother");

        public static IEnumerable<RelationEnumeration> GetAll() => GetAll<RelationEnumeration>();
    }
}