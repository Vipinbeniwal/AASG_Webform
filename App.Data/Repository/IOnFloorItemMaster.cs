using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IOnFloorItemMaster
    {
        IQueryable<OnFloorItemMaster> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<OnFloorItemMaster> GetByName(string Term);

        OnFloorItemMaster Create(OnFloorItemMaster entity, string loggedInUser);

        OnFloorItemMaster Update(OnFloorItemMaster entity, string loggedInUser);

        bool Delete(OnFloorItemMaster entity, string loggedInUser);

        bool validate(OnFloorItemMaster entity);
    }
}
