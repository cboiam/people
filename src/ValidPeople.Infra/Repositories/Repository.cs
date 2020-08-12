using Google.Cloud.Firestore;
using ValidPeople.Infra.Interfaces;

namespace ValidPeople.Infra.Repositories
{
    public abstract class Repository
    {
        public abstract string CollectionName { get; }
        protected CollectionReference Collection { get; }

        public Repository(IFirebaseConnection firebaseConnection)
        {
            Collection = firebaseConnection.Database.Collection(CollectionName);
        }
    }
}
