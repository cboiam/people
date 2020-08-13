using System;

namespace ValidPeople.Application.Responses.People
{
    public class PersonListResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Cpf { get; set; }
    }
}
