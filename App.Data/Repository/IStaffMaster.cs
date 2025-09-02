using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IStaffMaster
    {
        IQueryable<StaffMaster> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<StaffMaster> GetByName(string Term);

        StaffMaster Create(StaffMaster entity, string loggedInUser);

        StaffMaster Update(StaffMaster entity, string loggedInUser);

        bool Delete(StaffMaster entity, string loggedInUser);

        bool validate(StaffMaster entity);
    }
}
