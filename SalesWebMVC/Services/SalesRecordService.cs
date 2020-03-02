using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMVCContext _context;

        public SalesRecordService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate);
            }
            return await result
                .Include(x => x.Saller)
                .Include(x => x.Saller.Departament)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Departament,SalesRecord>>> FindByDateGroupAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate);
            }
            return await result
                .Include(x => x.Saller)
                .Include(x => x.Saller.Departament)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Saller.Departament)
                .ToListAsync();
        }
        public async Task<DateTime> FindMinDateAsync()
        {
            return await _context.SalesRecord.MinAsync(x => x.Date);
        }
    }
}
