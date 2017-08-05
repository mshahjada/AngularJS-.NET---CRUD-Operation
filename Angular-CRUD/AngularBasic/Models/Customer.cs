using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularBasic.Models
{
    public class Customer
    {
        public Customer()
        {
            CustomerId = 0;
            CustomerName = string.Empty;
            Address = string.Empty;
            ContactNo = string.Empty;
            Remarks = string.Empty;
        }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Remarks { get; set; }
    }

    public class DataSet
    {
        public static void Initialize()
        {
            customers = new List<Customer>();
            customers.Add(new Customer { CustomerId = 1, CustomerName = "Kamal", Address = "Bangladesh", ContactNo = "123", Remarks = "N/a" });
            customers.Add(new Customer { CustomerId = 2, CustomerName = "Toru", Address = "Japan", ContactNo = "123", Remarks = "N/a" });
            customers.Add(new Customer { CustomerId = 3, CustomerName = "Rased", Address = "Bangladesh", ContactNo = "123", Remarks = "N/a" });
            customers.Add(new Customer { CustomerId = 4, CustomerName = "Jiko", Address = "England", ContactNo = "123", Remarks = "N/a" });
            customers.Add(new Customer { CustomerId = 5, CustomerName = "Natasa", Address = "Germany", ContactNo = "123", Remarks = "N/a" });

        }
        private static List<Customer> customers { get; set; }


        public static List<Customer> AddCustomer(Customer customer)
        {
            customers.Add(customer);
            return customers;
        }

        public static List<Customer> EditCustomer(Customer customer)
        {
            customers.RemoveAll(x=>x.CustomerId == customer.CustomerId);
            customers.Add(customer);
            return customers;
        }

        public static List<Customer> DeleteCustomer(Customer customer)
        {
            customers.RemoveAll(x => x.CustomerId == customer.CustomerId);
            return customers;
        }

        public static List<Customer> GetAllCustomer()
        {
            return customers;
        }
    }
}