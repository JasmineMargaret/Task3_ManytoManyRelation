using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3_ManytoManyRelation.Abstractions;

namespace Task3_ManytoManyRelation.Controllers
{
    public class EmployeeSkillsViewController : Controller
    {
        private readonly IEmployeesService _employeeService;
        private readonly ISkillsService _skillService;

        public EmployeeSkillsViewController(IEmployeesService employeeService, ISkillsService skillService)
        {
            _employeeService = employeeService;
            _skillService = skillService;
        }
        public async Task<IActionResult> EmpIndex()
        {
            var result = await _employeeService.GetAllEmployees();
            return View(result);
        }
        public async Task<IActionResult> SkilIndex()
        {
            var result = await _skillService.GetAllSkills();
            return View(result);
        }
    }
}
