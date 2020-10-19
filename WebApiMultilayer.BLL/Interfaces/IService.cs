using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMultilayer.BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        bool Create(T item);
        bool Update(T item);
        bool Delete(int id);
        void Dispose();
    }
}
