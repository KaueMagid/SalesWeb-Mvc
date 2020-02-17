using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models.ViewModel
{
    public class SallerFormViewModel
    {
        public Saller Saller { get; set; }
        public ICollection<Departament> Departaments { get; set; }


    }
}
