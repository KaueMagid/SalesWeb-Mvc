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
            _context.Add(saller);
            _context.SaveChanges();
        }

        public Saller FindById(int id)
        {
            return _context.Saller.FirstOrDefault(x => x.Id == id);
        }
        
        public void Remove(int id)
        {
            var obj = _context.Saller.Find(id);
            _context.Saller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
