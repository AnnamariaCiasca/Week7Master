using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Master.Core.InterfaceRepositories
{
    public interface IRepository<T>
    {
        //CRUD
       public List<T> Fetch();
       public T Add(T item);
       public T Update(T item);
       public bool Delete(T item);


      //public T GetById(int id); questo non lo faccio perché ci sono sia Id interi che Id string, quindi devo farne una in ogni repository
    }
}
