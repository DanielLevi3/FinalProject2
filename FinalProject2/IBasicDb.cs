using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    interface IBasicDb<T> where T:IPOCO     
    {
        void Add(T t);
        T Get(long id);
        List<T> GetAll();
        void Remove(long id);
        void Update(T t);
    }
}
