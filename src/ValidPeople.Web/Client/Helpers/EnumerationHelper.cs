using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using ValidPeople.Web.Shared;

namespace ValidPeople.Web.Client.Helpers
{
    public static class EnumerationHelper
    {
        public static EnumerationViewModel SelectEnumeration(this ChangeEventArgs evt, IEnumerable<EnumerationViewModel> values)
        {
            var value = evt.Value.ToString();
            return values.First(h => h.Id == int.Parse(value));
        }
    }
}
