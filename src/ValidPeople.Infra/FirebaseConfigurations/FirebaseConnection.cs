using Firebase.Database;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Microsoft.Extensions.Options;
using System.IO;
using ValidPeople.Infra.Interfaces;

namespace ValidPeople.Infra.FirebaseConfigurations
{
    public class FirebaseConnection : IFirebaseConnection
    {
        public FirestoreDb Database { get; }

        public FirebaseConnection(IOptions<FirebaseConnectionOptions> options)
        {
            Database = FirestoreDb.Create(options.Value.ProjectId, new FirestoreClientBuilder
            {
                CredentialsPath = Path.Combine(Directory.GetCurrentDirectory(), options.Value.ServiceAccountFilePath)
            }.Build());
        }
    }
}
