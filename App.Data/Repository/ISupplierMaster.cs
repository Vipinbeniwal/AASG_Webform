using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface ISupplierMaster
    {
        IQueryable<SupplierMaster> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<SupplierMaster> GetByName(string Term);

        SupplierMaster Create(SupplierMaster entity, string loggedInUser);

        SupplierMaster Update(SupplierMaster entity, string loggedInUser);

        bool Delete(SupplierMaster entity, string loggedInUser);

        bool validate(SupplierMaster entity);
    }
}
