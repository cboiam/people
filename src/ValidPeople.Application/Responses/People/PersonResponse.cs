using System;
using System.Collections.Generic;
using ValidPeople.Domain.Enumerations;

namespace ValidPeople.Application.Responses.People
{
    public class PersonResponse
    {
        public Guid Id { get; set; }
        public NameResponse Name { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public IEnumerable<ParentResponse> Parents { get; set; }
        public CpfResponse Cpf { get; set; }
        public HobbyEnumeration Hobby { get; set; }
        public double Revenue { get; set; }
        public string Profession { get; set; }
        public EducationalLevelEnumeration EducationalLevel { get; set; }
        public StatusEnumeration Status { get; set; }
        public bool Cloned { get; set; }
    }
}
