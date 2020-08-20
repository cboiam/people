using System;
using System.Collections.Generic;
using ValidPeople.Domain.Enumerations;

namespace ValidPeople.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public string Email { get; private set; }
        public DateTime Birth { get; private set; }
        public IEnumerable<Parent> Parents { get; private set; }
        public Cpf Cpf { get; private set; }
        public HobbyEnumeration Hobby { get; private set; }
        public double Revenue { get; private set; }
        public string Profession { get; private set; }
        public EducationalLevelEnumeration EducationalLevel { get; private set; }
        public StatusEnumeration Status { get; private set; }
        public bool Cloned { get; private set; }

        public Person(Guid id, Name name, string email, DateTime birth, IEnumerable<Parent> parents, Cpf cpf, HobbyEnumeration hobby, double revenue, string profession, EducationalLevelEnumeration educationalLevel, StatusEnumeration status, bool cloned)
        {
            Id = id;
            Name = name;
            Email = email;
            Birth = birth;
            Parents = parents;
            Cpf = cpf;
            Hobby = hobby;
            Revenue = revenue;
            Profession = profession;
            EducationalLevel = educationalLevel;
            Status = status;
            Cloned = cloned;
        }

        public Person(Name name, string email, DateTime birth, IEnumerable<Parent> parents, Cpf cpf, HobbyEnumeration hobby, double revenue, string profession, EducationalLevelEnumeration educationalLevel, StatusEnumeration status, bool cloned)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Birth = birth;
            Parents = parents;
            Cpf = cpf;
            Hobby = hobby;
            Revenue = revenue;
            Profession = profession;
            EducationalLevel = educationalLevel;
            Status = status;
            Cloned = cloned;
        }
    }
}