using System;

namespace ValidPeople.Application.Requests.People
{
    public class CpfRequest
    {
        public string Number { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime Emission { get; set; }
    }
}
