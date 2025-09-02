using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface Ixp_ProcurementHeader
    {
        IQueryable<xp_ProcurementHeader> GetAll();
        IQueryable<vwxp_ProcurementHeaderSupplierDetail> GetAllxp_ProcurementHeaderSupplierDetail();

        IQueryable GetbyId(int Id);

        IQueryable<xp_ProcurementHeader> GetByName(string Term);

        xp_ProcurementHeader Create(xp_ProcurementHeader entity, string loggedInUser);

        xp_ProcurementHeader Update(xp_ProcurementHeader entity, string loggedInUser);

        bool Delete(xp_ProcurementHeader entity, string loggedInUser);

        bool validate(xp_ProcurementHeader entity);
    }
}
