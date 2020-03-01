using System.Collections.Generic;
using System.Linq;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SallerService
    {
        private readonly SalesWebMVCContext _context;
        
        public SallerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Saller>> FindAllAsync()
        {
            return await _context.Saller.ToListAsync();
        }

        public async Task InsertAsync(Saller saller)
        {
            _context.Add(saller);
            await _context.SaveChangesAsync();
        }

        public async Task<Saller> FindByIdAsync(int id)
        {
            return await _context.Saller.Include(obj => obj.Departament).FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Saller.FindAsync(id);
                _context.Saller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task Update(Saller saller)
        {
            bool hasAny = await _context.Saller.AnyAsync(x => x.Id == saller.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(saller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
