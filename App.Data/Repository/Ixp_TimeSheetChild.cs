using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface Ixp_TimeSheetChild
    {
        IQueryable<xp_TimeSheetChild> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<xp_TimeSheetChild> GetByName(string Term);

        xp_TimeSheetChild Create(xp_TimeSheetChild entity, string loggedInUser);

        xp_TimeSheetChild Update(xp_TimeSheetChild entity, string loggedInUser);

        bool Delete(xp_TimeSheetChild entity, string loggedInUser);

        bool validate(xp_TimeSheetChild entity);
    }
}
