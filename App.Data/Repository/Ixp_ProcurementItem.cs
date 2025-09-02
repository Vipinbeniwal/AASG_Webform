using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface Ixp_ProcurementItem
    {
        IQueryable<xp_ProcurementItem> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<xp_ProcurementItem> GetByName(string Term);

        xp_ProcurementItem Create(xp_ProcurementItem entity, string loggedInUser);

        xp_ProcurementItem Update(xp_ProcurementItem entity, string loggedInUser);

        bool Delete(xp_ProcurementItem entity, string loggedInUser);

        bool validate(xp_ProcurementItem entity);
    }
}
