using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3_ManytoManyRelation.Models;

namespace Task3_ManytoManyRelation.Abstractions
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employeeswithskills>> GetAllEmployees();
    }
}