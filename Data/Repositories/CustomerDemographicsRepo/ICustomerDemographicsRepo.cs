﻿using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.Data.Repositories.CustomerDemographicsRepo
{
    public interface ICustomerDemographicsRepo
    {
        Task<IList<CustomerDemographics>> GetAllAsync();
        Task<CustomerDemographics> GetOne(string id);
    }
}
