using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Heandlers.OrderDetailHeandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OrderDetailId);

            if (values != null) 
            {
                values.OrderDetailId = command.OrderDetailId;
                values.ProductId = command.ProductId;
                values.ProductName = command.ProductName;
                values.ProductPrice = command.ProductPrice;
                values.ProductAmount = command.ProductAmount;
                values.ProductTotalPrice = command.ProductTotalPrice;
                values.OrderingId = command.OrderingId;

                await _repository.UpdateAsync(values);
            }
            else
            {
                throw new Exception($"OrderDetail with ID {command.OrderDetailId} not found.");
            }
        }
    }
}
