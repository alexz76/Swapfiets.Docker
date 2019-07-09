using MongoDB.Driver;
using MongoDb4.Prototype.Entities.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDb4.Prototype.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IRepository<Order> _repository;
        
        public OrderRepository(
            IRepository<Order> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IList<Order>> ListAllAsync()
        {
            var collection = _repository.GetCollection("orders");

            return await collection.AsQueryable().ToListAsync().ConfigureAwait(false);
        }

        public async Task InsertAsync(Order order)
        {
            var collection = _repository.GetCollection("orders");

            await collection.InsertOneAsync(order);
        }

        /// <summary>
        /// TODO : Not working as expected
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public async Task InsertBulkAsync(IList<Order> orders)
        {
            var session = _repository.GetSession();
            session.StartTransaction();

            var collection = _repository.GetCollection("orders");

            try
            {
                foreach (var order in orders)
                {
                    await collection.InsertOneAsync(session, order);
                }

                await session.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
            }
        }
    }

    public interface IOrderRepository
    {
        Task<IList<Order>> ListAllAsync();

        Task InsertAsync(Order order);

        Task InsertBulkAsync(IList<Order> orders);
    }
}
