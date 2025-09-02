using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface Ixp_TimeSheetHeader
    {
        IQueryable<xp_TimeSheetHeader> GetAll();
        
        IQueryable GetbyId(int Id);

        IQueryable<xp_TimeSheetHeader> GetByName(string Term);

        xp_TimeSheetHeader Create(xp_TimeSheetHeader entity, string loggedInUser);

        xp_TimeSheetHeader Update(xp_TimeSheetHeader entity, string loggedInUser);

        bool Delete(xp_TimeSheetHeader entity, string loggedInUser);

        bool validate(xp_TimeSheetHeader entity);
    }
}
