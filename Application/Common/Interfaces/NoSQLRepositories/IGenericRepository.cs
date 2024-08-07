using Domain;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Application.Common.Interfaces.NoSQLRepositories
{
    public interface IGenericRepository<TDocument> where TDocument : NoSQLBaseEntity
    {
        IMongoQueryable<TDocument> Get();
        Task<TDocument> GetAsync(string id);
        Task InsertAsync(TDocument document);
        Task UpdateAsync(string id, TDocument sampleEntity);
        Task DeleteAsync(string id);
    }
}
