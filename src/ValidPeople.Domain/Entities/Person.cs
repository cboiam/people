using System;
using System.Collections.Generic;

namespace ValidPeople.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public DateTime Birth { get; set; }
        public IEnumerable<Parent> Parent { get; set; }
        public Cpf Cpf { get; set; }
        public HobbyEnumeration Hobby { get; set; }
        public decimal Renda { get; set; }
        public decimal AvarageCollegeGrade { get; set; }
        public IEnumerable<string> FavoriteGames { get; set; }
    }
}