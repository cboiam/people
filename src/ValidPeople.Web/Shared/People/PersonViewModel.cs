using System;
using System.Collections.Generic;

namespace ValidPeople.Web.Shared.People
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }
        public NameViewModel Name { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public List<ParentViewModel> Parents { get; set; }
        public CpfViewModel Cpf { get; set; }
        public EnumerationViewModel Hobby { get; set; }
        public double Revenue { get; set; }
        public string Profession { get; set; }
        public EnumerationViewModel EducationalLevel { get; set; }
        public EnumerationViewModel Status { get; set; }
        public bool Cloned { get; set; }
    }
}