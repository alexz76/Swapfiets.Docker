using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDb4.Prototype.Entities.Infrastructure;
using MongoDb4.Prototype.Infrastructure.Entities;
using System;

namespace MongoDb4.Prototype.Infrastructure
{
    public class Database : IDatabase
    {
        private readonly string _connectionString;

        private readonly IMongoDatabase _products;
        private readonly IMongoClient _client;

        public Database(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            _connectionString = connectionString;

            BsonClassMap.RegisterClassMap<Order>();
            BsonClassMap.RegisterClassMap<Inventory>();

            _client = new MongoClient(_connectionString);

            // TODO : Extract Database from connection string
            _products = _client.GetDatabase("products");
        }

        public IMongoCollection<T> GetCollection<T>(string name)
            where T : IEntity
        {
            return _products.GetCollection<T>(name);
        }

        public IClientSessionHandle GetSession()
        {
            return _client.StartSession();
        }
    }

    public interface IDatabase
    {
        IMongoCollection<T> GetCollection<T>(string name)
            where T : IEntity;

        IClientSessionHandle GetSession();
    }
}
