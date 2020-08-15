using System;

namespace ValidPeople.Web.Shared.People
{
    public class CpfViewModel
    {
        public string Number { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime Emission { get; set; }
    }
}
