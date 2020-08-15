using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

namespace ValidPeople.Infra.Models
{
    [FirestoreData]
    public class Person
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public Name Name { get; set; }

        [FirestoreProperty]
        public string Email { get; set; }

        [FirestoreProperty]
        public DateTime Birth { get; set; }

        [FirestoreProperty]
        public IEnumerable<Parent> Parents { get; set; }

        [FirestoreProperty]
        public Cpf Cpf { get; set; }

        [FirestoreProperty]
        public int Hobby { get; set; }

        [FirestoreProperty]
        public double Revenue { get; set; }
    }
}
