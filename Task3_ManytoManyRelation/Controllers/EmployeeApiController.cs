using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Task3_ManytoManyRelation.Models;

namespace Task3_ManytoManyRelation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private SQLiteDBContext _context;

        public EmployeeApiController(SQLiteDBContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> Get()
        {

            return await _context.Employees.Include(d => d.skillmaps).ToListAsync();
        }

        [HttpGet, Route("GetEmployeeList")]
        public ActionResult GetEmployeeList()
        {
            var skills = _context.Employees.Include(s => s.skillmaps).ThenInclude(s => s.skills).ToList();

            return new OkObjectResult(skills);
        }
    }
}
