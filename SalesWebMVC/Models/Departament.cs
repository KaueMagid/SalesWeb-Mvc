using System;
using System.Linq;
using System.Collections.Generic;

namespace SalesWebMVC.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Saller> Sallers { get; set; } = new List<Saller>();

        public Departament()
        {
        }

        public Departament(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSaller(Saller saller)
        {
            Sallers.Add(saller);
        }

        public double TotalDepartament(DateTime initial, DateTime final)
        {
            return Sallers.Sum(saller => saller.TotalSales(initial,final));          
        }
    }
}
