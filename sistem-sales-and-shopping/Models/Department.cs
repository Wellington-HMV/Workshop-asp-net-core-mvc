using System.Collections.Generic;
using System;
using System.Linq;

namespace system_sales_and_shopping.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department() { }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void AddSaler(Seller seller)
        {
            Sellers.Add(seller);
        }
        public void RemoveSaler(Seller seller)
        {
            Sellers.Remove(seller);
        }

        public double TotalSales(DateTime inital, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(inital, final));
        }


    }

}

