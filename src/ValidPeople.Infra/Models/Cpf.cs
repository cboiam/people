using Google.Cloud.Firestore;
using System;

namespace ValidPeople.Infra.Models
{
    [FirestoreData]
    public class Cpf
    {
        [FirestoreProperty]
        public string Number { get; set; }

        [FirestoreProperty]
        public Timestamp Expiration { get; set; }

        [FirestoreProperty]
        public Timestamp Emission { get; set; }
    }
}
