using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.Data.Repositories.EmployeesRepo
{
    public interface IEmployeesRepo
    {
        Task<IList<Employees>> GetAllAsync();
        Task<Employees> GetOne(int? id);
    }
}
