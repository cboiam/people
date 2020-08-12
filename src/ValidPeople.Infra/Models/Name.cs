using Google.Cloud.Firestore;

namespace ValidPeople.Infra.Models
{
    [FirestoreData]
    public class Name
    {
        [FirestoreProperty]
        public string FirstName { get; set; }

        [FirestoreProperty]
        public string LastName { get; set; }
    }
}
