using System.Collections.Generic;

namespace ValidPeople.Domain.Enumerations
{
    public class HobbyEnumeration : Enumeration
    {
        public static HobbyEnumeration Gaming = new HobbyEnumeration(1, "Gaming");

        public HobbyEnumeration() { }

        public HobbyEnumeration(int id, string name) 
            : base(id, name) { }

        public static IEnumerable<HobbyEnumeration> GetAll() => GetAll<HobbyEnumeration>();
    }
}