using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IActivityLog
    {
        IQueryable<ActivityLog> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<ActivityLog> GetByName(string Term);

        ActivityLog Create(ActivityLog entity, string loggedInUser);

        ActivityLog Update(ActivityLog entity, string loggedInUser);

        bool Delete(ActivityLog entity, string loggedInUser);

        bool validate(ActivityLog entity);
    }
}
