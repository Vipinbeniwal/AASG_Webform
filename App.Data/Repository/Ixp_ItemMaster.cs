using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface Ixp_ItemMaster
    {
        IQueryable<xp_ItemMaster> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<xp_ItemMaster> GetByName(string Term);

        xp_ItemMaster Create(xp_ItemMaster entity, string loggedInUser);

        xp_ItemMaster Update(xp_ItemMaster entity, string loggedInUser);

        bool Delete(xp_ItemMaster entity, string loggedInUser);

        bool validate(xp_ItemMaster entity);
    }
}
