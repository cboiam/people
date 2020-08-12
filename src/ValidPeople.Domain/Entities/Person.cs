using System;
using System.Collections.Generic;
using ValidPeople.Domain.Enumerations;

namespace ValidPeople.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public DateTime Birth { get; private set; }
        public IEnumerable<Parent> Parents { get; private set; }
        public Cpf Cpf { get; private set; }
        public HobbyEnumeration Hobby { get; private set; }
        public double Revenue { get; private set; }

        public Person(Guid id, Name name, DateTime birth, IEnumerable<Parent> parents, Cpf cpf, HobbyEnumeration hobby, double revenue)
        {
            Id = id;
            Name = name;
            Birth = birth;
            Parents = parents;
            Cpf = cpf;
            Hobby = hobby;
            Revenue = revenue;
        }
    }
}