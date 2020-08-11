using System;

namespace ValidPeople.Domain.Entities
{
    public class Cpf
    {
        public string Number { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime Emission { get; set; }
    }
}