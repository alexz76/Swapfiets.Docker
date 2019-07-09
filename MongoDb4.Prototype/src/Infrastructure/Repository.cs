using MongoDB.Driver;
using MongoDb4.Prototype.Infrastructure.Entities;
using System;

namespace MongoDb4.Prototype.Infrastructure
{
    public class Repository<T> : IRepository<T>
        where T : IEntity
    {
        private readonly IDatabase _database;

        public Repository(IDatabase database)
            => _database = database ?? throw new ArgumentNullException(nameof(database));

        public IMongoCollection<T> GetCollection(string name)
            => _database.GetCollection<T>(name);

        public IClientSessionHandle GetSession()
            => _database.GetSession();
    }

    public interface IRepository<T>
        where T : IEntity
    {
        IMongoCollection<T> GetCollection(string name);

        IClientSessionHandle GetSession();
    }
}
