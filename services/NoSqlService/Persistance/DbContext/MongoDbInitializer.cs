using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlService.Persistance.DbContext
{
    public class MongoDbInitializer
    {
        private readonly IMongoDatabase _database;

        public MongoDbInitializer(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public void Initialize()
        {
            // Yaratmaq istədiyin collection-lar
            var collectionsToCreate = new[]
            {
            "ErrorLogs",
            "NotificationLogs",
            "WarningLogs"
        };

            var existingCollections = _database.ListCollectionNames().ToList();

            foreach (var collection in collectionsToCreate)
            {
                if (!existingCollections.Contains(collection))
                {
                    _database.CreateCollection(collection);
                }
            }
        }
    }

}
