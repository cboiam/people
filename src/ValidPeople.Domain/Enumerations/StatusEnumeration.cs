using System.Collections.Generic;

namespace ValidPeople.Domain.Enumerations
{
    public class StatusEnumeration : Enumeration
    {
        public StatusEnumeration() {}

        public StatusEnumeration(int id, string name) : base (id, name) {}

        public static StatusEnumeration Inactive = new StatusEnumeration (1, "Inactive");
        public static StatusEnumeration Active = new StatusEnumeration (2, "Active");
        public static StatusEnumeration Suspended = new StatusEnumeration (3, "Suspended");

        public static IEnumerable<StatusEnumeration> GetAll() => GetAll<StatusEnumeration>();
    }
}