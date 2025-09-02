using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IData<T>
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetbyId(int Id);

        IQueryable<T> GetByName(string Term);

        List<T> Search(T entity);

        T Create(T entity, string loggedInUser);

        T Update(T entity, string loggedInUser);

        bool Delete(T entity, string loggedInUser);

        bool validate(T entity);

        //T SetTimeStamp(T entity, bool isNew, string loggedInUser);

    }
}
