using System.Collections.Generic;

namespace ValidPeople.Web.Shared
{
    public class Resource
    {
        public IEnumerable<EnumerationViewModel> Hobbies { get; set; }
        public IEnumerable<EnumerationViewModel> ParentRelations { get; set; }
        public IEnumerable<EnumerationViewModel> EducationalLevels { get; set; }
        public IEnumerable<EnumerationViewModel> Status { get; set; }
    }
}
