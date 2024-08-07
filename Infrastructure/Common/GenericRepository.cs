using Application.Common.Interfaces;
using Application.Common.Interfaces.NoSQLRepositories;
using Domain;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Infrastructure.Common
{
    public abstract class GenericRepository<TDocument> : IGenericRepository<TDocument>
        where TDocument : NoSQLBaseEntity
    {
        internal readonly IMongoCollection<TDocument> DocumentCollection;

        public GenericRepository(
            INoSQLDatabaseSettings noSQLDatabaseSettings,
            IConfiguration configuration,
            string collectionName)
        {
            var mongoClient = new MongoClient(configuration.GetConnectionString("NoSQL"));
            var mongoDatabase = mongoClient.GetDatabase(noSQLDatabaseSettings.DatabaseName);
            DocumentCollection = mongoDatabase.GetCollection<TDocument>(collectionName);
        }

        public IMongoQueryable<TDocument> Get() =>
             DocumentCollection.AsQueryable();

        public async Task<TDocument> GetAsync(string id) =>
            await DocumentCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task InsertAsync(TDocument document) =>
            await DocumentCollection.InsertOneAsync(document);

        public async Task UpdateAsync(string id, TDocument document) =>
            await DocumentCollection.ReplaceOneAsync(x => x.Id == id, document);

        public async Task DeleteAsync(string id) =>
            await DocumentCollection.DeleteOneAsync(x => x.Id == id);
    }
}
