using GameProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Business.Interfaces
{
    public interface ICustomerService
    {
        Customer Register();
        bool Check(Customer customer);
    }
}
