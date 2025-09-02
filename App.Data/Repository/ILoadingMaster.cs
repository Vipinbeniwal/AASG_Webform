using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface ILoadingMaster
    {
        IQueryable<LoadingMaster> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<LoadingMaster> GetByName(string Term);

        LoadingMaster Create(LoadingMaster entity, string loggedInUser);

        LoadingMaster Update(LoadingMaster entity, string loggedInUser);

        bool Delete(LoadingMaster entity, string loggedInUser);

        bool validate(LoadingMaster entity);

        IQueryable GetbyOrderNumber(string Id);
    }
}
