using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IPurchaseItem
    {
        IQueryable<PurchaseItem> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<PurchaseItem> GetByName(string Term);

        PurchaseItem Create(PurchaseItem entity, string loggedInUser);

        PurchaseItem Update(PurchaseItem entity, string loggedInUser);

        bool Delete(PurchaseItem entity, string loggedInUser);

        bool validate(PurchaseItem entity);
    }
}
