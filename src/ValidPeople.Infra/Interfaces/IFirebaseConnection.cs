using Google.Cloud.Firestore;

namespace ValidPeople.Infra.Interfaces
{
    public interface IFirebaseConnection
    {
        FirestoreDb Database { get; }
    }
}
