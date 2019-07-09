using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDb4.Prototype.Entities.Infrastructure;
using MongoDb4.Prototype.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MongoDb4.Prototype
{
    public class HostStartup : IHostedService, IDisposable
    {
        private readonly ILogger<HostStartup> _logger;
        private readonly IOrderRepository _orderRepository;

        public HostStartup(
            ILogger<HostStartup> logger,
            IOrderRepository orderRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting");

            await BatchOperationAsync();

            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping.");

            await Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TODO : Do manual dispose
            }
        }

        private async Task BatchOperationAsync()
        {
            await _orderRepository.InsertAsync(new Order
            {
                Number = "A123OP",
                Items = new List<object> { new { Id = "123", Quantity = 10 } }
            });

            var orders = new List<Order>();

            for(int i = 0; i < 10; i++)
            {
                orders.Add(new Order
                {
                    Number = $"A{i}-OP",
                    Items = new List<object> { new { Id = "123", Quantity = 10 } }
                });
            }

            await _orderRepository.InsertBulkAsync(orders);

            var allOrders = await _orderRepository.ListAllAsync();
        }
    }
}
