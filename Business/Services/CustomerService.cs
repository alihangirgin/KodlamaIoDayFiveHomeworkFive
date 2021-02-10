using GameProject.Business.Interfaces;
using GameProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Business.Services
{
    public class CustomerService : ICustomerService
    {
        public Customer Register()
        {
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter Identity Number:");
            string identityNumber = Console.ReadLine();
            Console.WriteLine("Year of Birth");
            int year = Convert.ToInt32(Console.ReadLine());

            var customer = new Customer();
            customer.Name = name;
            customer.Surname = surname;
            customer.IdentityNumber = identityNumber;
            customer.YearOfBirth = year;

            return customer;
        }
    }
}
