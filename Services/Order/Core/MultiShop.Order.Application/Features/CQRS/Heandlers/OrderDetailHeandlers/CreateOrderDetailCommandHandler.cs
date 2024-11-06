﻿using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Heandlers.OrderDetailHeandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                ProductId = createOrderDetailCommand.ProductId,
                ProductName = createOrderDetailCommand.ProductName,
                ProductPrice = createOrderDetailCommand.ProductPrice,
                ProductAmount = createOrderDetailCommand.ProductAmount,
                ProductTotalPrice = createOrderDetailCommand.ProductTotalPrice,
                OrderingId = createOrderDetailCommand.OrderingId,
            });
        }
    }
}