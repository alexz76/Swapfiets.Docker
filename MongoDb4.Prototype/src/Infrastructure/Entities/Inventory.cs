using MongoDb4.Prototype.Infrastructure.Entities;
using System;

namespace MongoDb4.Prototype.Entities.Infrastructure
{
    public class Inventory : IEntity
    {
        public string CollectionName => "inventories";

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}
