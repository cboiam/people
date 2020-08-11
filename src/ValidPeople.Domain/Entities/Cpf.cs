using System;

namespace ValidPeople.Domain.Entities
{
    public class Cpf
    {
        public string Number { get; private set; }
        public DateTime Expiration { get; private set; }
        public DateTime Emission { get; private set; }

        public Cpf(string number, DateTime expiration, DateTime emission)
        {
            Number = number;
            Expiration = expiration;
            Emission = emission;
        }
    }
}