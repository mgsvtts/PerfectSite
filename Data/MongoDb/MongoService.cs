using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PerfectSite.Models;

namespace PerfectSite.Data.MongoDb
{
    public class MongoService
    {
        private readonly IMongoCollection<Comment> _collection;

        public MongoService(IOptions<MongoOptions> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _collection = database.GetCollection<Comment>(mongoDBSettings.Value.CollectionName);
        }
    }
}