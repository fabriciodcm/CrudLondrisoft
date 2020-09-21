using CrudLondrisoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudLondrisoft.Services
{
    public interface IService<out T, in A>
    {
        T Create(A a);
        T FindByID(int Id);
        IEnumerable<T> FindAll();
        T Update(A a);
        T Delete(int Id);
    }
}
