﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    //sadece bir adresin ID ile sorgulanması
    public class GetAddressByIdQuery
    {
        public int Id { get; set; }

        public GetAddressByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
