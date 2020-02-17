using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SallerService
    {
        private readonly SalesWebMVCContext _context;
        
        public SallerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Saller> FindAll()
        {
            return _context.Saller.ToList();
        }

        public void Insert(Saller saller)
        {
            saller.Departament = _context.Departament.First();
            _context.Add(saller);
            _context.SaveChanges();
        }
    }
}
