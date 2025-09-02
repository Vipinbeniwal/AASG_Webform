using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface ITourExpenseItem
    {
        IQueryable<TourExpenseItem> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<TourExpenseItem> GetByName(string Term);

        TourExpenseItem Create(TourExpenseItem entity, string loggedInUser);

        TourExpenseItem Update(TourExpenseItem entity, string loggedInUser);

        bool Delete(TourExpenseItem entity, string loggedInUser);

        bool validate(TourExpenseItem entity);
    }
}
