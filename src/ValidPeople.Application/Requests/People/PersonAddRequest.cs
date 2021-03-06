﻿using System;
using System.Collections.Generic;
using ValidPeople.Domain.Enumerations;

namespace ValidPeople.Application.Requests.People
{
    public class PersonAddRequest
    {
        public NameRequest Name { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public IEnumerable<ParentRequest> Parents { get; set; }
        public CpfRequest Cpf { get; set; }
        public HobbyEnumeration Hobby { get; set; }
        public double Revenue { get; set; }
        public string Profession { get; set; }
        public EducationalLevelEnumeration EducationalLevel { get; set; }
        public bool Cloned { get; set;}
    }
}
