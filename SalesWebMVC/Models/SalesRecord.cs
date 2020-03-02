using System;
using System.ComponentModel.DataAnnotations;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "${0:F2}")]
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Saller Saller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Saller saller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Saller = saller;
        }
    }
}
