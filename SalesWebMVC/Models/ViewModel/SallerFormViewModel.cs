using System.Collections.Generic;

namespace SalesWebMVC.Models.ViewModel
{
    public class SallerFormViewModel
    {
        public Saller Saller { get; set; }
        public ICollection<Departament> Departaments { get; set; }


    }
}
