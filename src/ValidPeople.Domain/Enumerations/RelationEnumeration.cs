using System.Collections.Generic;

namespace ValidPeople.Domain.Enumerations
{
    public class RelationEnumeration : Enumeration
    {
        public RelationEnumeration(int id, string name) 
            : base(id, name) { }

        public static RelationEnumeration Pai = new RelationEnumeration(1, "Pai");
        public static RelationEnumeration Mae = new RelationEnumeration(2, "Mãe");

        public static IEnumerable<RelationEnumeration> GetAll() => GetAll<RelationEnumeration>();
    }
}