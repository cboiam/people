using System.Collections.Generic;

namespace ValidPeople.Domain.Enumerations
{
    public class EducationalLevelEnumeration : Enumeration
    {
        public EducationalLevelEnumeration() { }

        public EducationalLevelEnumeration(int id, string name) 
            : base(id, name) { }

        public static EducationalLevelEnumeration None = new EducationalLevelEnumeration(0, "None");
        public static EducationalLevelEnumeration PrimaryIncomplete = new EducationalLevelEnumeration(1, "Incomplete Primary School");
        public static EducationalLevelEnumeration PrimaryComplete = new EducationalLevelEnumeration(2, "Complete Primary School");
        public static EducationalLevelEnumeration HighSchoolIncomplete = new EducationalLevelEnumeration(3, "Incomplete High School");
        public static EducationalLevelEnumeration HighSchoolComplete = new EducationalLevelEnumeration(4, "Complete High School");
        public static EducationalLevelEnumeration HigherIncomplete = new EducationalLevelEnumeration(5, "Incomplete Higher Education");
        public static EducationalLevelEnumeration HigherComplete = new EducationalLevelEnumeration(6, "Complete Higher Education");

        public static IEnumerable<EducationalLevelEnumeration> GetAll() => GetAll<EducationalLevelEnumeration>();
    }
}