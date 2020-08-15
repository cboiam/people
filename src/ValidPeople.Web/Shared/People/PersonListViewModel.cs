using System;

namespace ValidPeople.Web.Shared.People
{
    public class PersonListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Cpf { get; set; }
    }
}
