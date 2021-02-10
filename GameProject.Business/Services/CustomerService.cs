using GameProject.Business.DTOs;
using GameProject.Business.Interfaces;
using GameProject.Data.Entities;
using MernisServiceReference;
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
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Surname:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Identity Number:");
            string nationalityId = Console.ReadLine();
            Console.WriteLine("Year of Birth");
            int year = Convert.ToInt32(Console.ReadLine());

            var customer = new Customer();
            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.NationalityId = nationalityId;
            customer.YearOfBirth = year;

            return customer;
        }

        public bool Check(Customer customer)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            return client.TCKimlikNoDogrulaAsync(
                new TCKimlikNoDogrulaRequest
                (new TCKimlikNoDogrulaRequestBody(Convert.ToInt64(customer.NationalityId), customer.FirstName.ToUpper(),
                customer.LastName.ToUpper(), customer.YearOfBirth
                ))).Result.Body.TCKimlikNoDogrulaResult;
        }
    }
}
