using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3_ManytoManyRelation.Models;

namespace Task3_ManytoManyRelation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsApiController : ControllerBase
    {
        private SQLiteDBContext _context;

        public SkillsApiController(SQLiteDBContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skills>>> Get()
        {

            return await _context.Skills.Include(d => d.skillmaps).ToListAsync();
        }

        [HttpGet, Route("GetSkillsList")]
        public ActionResult GetSkillsList()
        {
            var skills = _context.Skills.Include(s => s.skillmaps).ThenInclude(s => s.employees).ToList();

            return new OkObjectResult(skills);
        }
    }
}
