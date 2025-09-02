using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface ITourExpenseHeader
    {
        IQueryable<TourExpenseHeader> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<TourExpenseHeader> GetByName(string Term);

        TourExpenseHeader Create(TourExpenseHeader entity, string loggedInUser);

        TourExpenseHeader Update(TourExpenseHeader entity, string loggedInUser);

        bool Delete(TourExpenseHeader entity, string loggedInUser);

        bool validate(TourExpenseHeader entity);
    }
}
