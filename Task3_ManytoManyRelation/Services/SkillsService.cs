using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3_ManytoManyRelation.Abstractions;
using Task3_ManytoManyRelation.Models;

namespace trainingWFM.Services
{
    public class SkillsService : ISkillsService
    {
        private readonly SQLiteDBContext _context;
        public SkillsService(SQLiteDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Skillswithemployees>> GetAllSkills()
        {
            var result = await _context.Skills.Include(x => x.skillmaps).ThenInclude(x => x.skills).Select(x => new Skillswithemployees
            {
                skillid = x.skillid,
                skillname = x.skillname,
                Employees = x.skillmaps.Select(y => y.employees.employee_name).ToList()
            }).ToListAsync();
            return result;
        }
    }
}