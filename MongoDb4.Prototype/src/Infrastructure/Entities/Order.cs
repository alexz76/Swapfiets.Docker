using MongoDB.Bson;
using MongoDb4.Prototype.Infrastructure.Entities;
using System;
using System.Collections.Generic;

namespace MongoDb4.Prototype.Entities.Infrastructure
{
    public class Order : IEntity
    {
        public ObjectId Id { get; set; }

        public string CollectionName => "orders";

        public string Number { get; set; }

        public ICollection<object> Items { get; set; }

        public DateTime Created { get; set; }
    }
}
