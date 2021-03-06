﻿using GraphQL.Types;
using graphqldemo.Data.Repositories.EmployeeTerritoriesRepo;
using graphqldemo.Data.Repositories.OrdersRepo;
using graphqldemo.Helpers;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class EmployeesType : ObjectGraphType<Employees>
    {
        public EmployeesType(ContextServiceLocator contextServiceLocator)
        {
            Field(t => t.EmployeeId, type:typeof(IdGraphType));
            Field(t => t.LastName);
            Field(t => t.FirstName);
            Field(t => t.Title);
            Field(t => t.TitleOfCourtesy);
            Field(t => t.BirthDate, type:typeof(DateGraphType));
            Field(t => t.HireDate, type: typeof(DateGraphType));
            Field(t => t.Address);
            Field(t => t.City);
            Field(t => t.Region);
            Field(t => t.PostalCode);
            Field(t => t.Country);
            Field(t => t.HomePhone);
            Field(t => t.Extension);
            Field(t => t.Photo, type:typeof(StringGraphType));
            Field(t => t.Notes);
            Field(t => t.ReportsTo, type:typeof(IntGraphType));
            Field(t => t.PhotoPath);
            Field<ListGraphType<OrdersType>>(
                name: "OrdersList",
                resolve: context => contextServiceLocator.OrdersRepo.GetAllAsync()
                );
            Field<ListGraphType<EmployeeTerritoriesType>>(
                name: "Employeeteritories",
                resolve: context => contextServiceLocator.EmployeeTerritoriesRepo.GetAllAsync());
        }
    }
}
