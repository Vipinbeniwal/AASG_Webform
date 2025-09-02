using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface ITourMaster
    {
        IQueryable<TourMaster> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<TourMaster> GetByName(string Term);

        TourMaster Create(TourMaster entity, string loggedInUser);

        TourMaster Update(TourMaster entity, string loggedInUser);

        bool Delete(TourMaster entity, string loggedInUser);

        bool validate(TourMaster entity);
    }
}
