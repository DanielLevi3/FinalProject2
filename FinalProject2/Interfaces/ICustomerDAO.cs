using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public interface ICustomerDAO : IBasicDb<Customers>
    {
        Customers GetCustomerByUserame(string name);
    }
}
