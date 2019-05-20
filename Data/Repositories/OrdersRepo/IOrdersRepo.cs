﻿using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.Data.Repositories.OrdersRepo
{
    public interface IOrdersRepo
    {
        Task<IList<Orders>> GetAllAsync(ICollection<Orders> orders);
        Task<IList<Orders>> GetAllAsync(int id);
        Task<Orders> GetOne(string id);
    }
}
