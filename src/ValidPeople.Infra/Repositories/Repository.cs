using Google.Cloud.Firestore;
using ValidPeople.Infra.Interfaces;

namespace ValidPeople.Infra.Repositories
{
    public abstract class Repository
    {
        public abstract string CollectionName { get; }
        public FirestoreDb Database { get; }
        protected CollectionReference Collection { get; }

        protected Repository(IFirebaseConnection firebaseConnection)
        {
            Database = firebaseConnection.Database;
            Collection = firebaseConnection.Database.Collection(CollectionName);
        }
    }
}
