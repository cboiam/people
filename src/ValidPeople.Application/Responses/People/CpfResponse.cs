using System;

namespace ValidPeople.Application.Responses.People
{
    public class CpfResponse
    {
        public string Number { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime Emission { get; set; }
    }
}
