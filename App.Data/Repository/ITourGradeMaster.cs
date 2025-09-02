using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface ITourGradeMaster
    {
        IQueryable<TourGradeMaster> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<TourGradeMaster> GetByName(string Term);

        TourGradeMaster Create(TourGradeMaster entity, string loggedInUser);

        TourGradeMaster Update(TourGradeMaster entity, string loggedInUser);

        bool Delete(TourGradeMaster entity, string loggedInUser);

        bool validate(TourGradeMaster entity);
    }
}
