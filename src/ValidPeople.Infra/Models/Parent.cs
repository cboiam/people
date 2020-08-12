using Google.Cloud.Firestore;

namespace ValidPeople.Infra.Models
{
    [FirestoreData]
    public class Parent
    {
        [FirestoreProperty]
        public Name Name { get; set; }

        [FirestoreProperty]
        public int Relation { get; set; }
    }
}
