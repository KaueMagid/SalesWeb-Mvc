using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class DepartamentService
    {
        private readonly SalesWebMVCContext _context;

        public DepartamentService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Departament>> FindAllAsync()
        {
            return await _context.Departament.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
