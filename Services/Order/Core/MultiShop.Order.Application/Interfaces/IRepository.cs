﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Interfaces
{
    public interface IRepository <T> where T : class
    {
        Task <List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task DeleteAsync(T entity);

        Task UpdateAsync(T entity);

        Task CreateAsync(T entity);

        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}