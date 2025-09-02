using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface ISaleItem
    {
        IQueryable<SaleItem> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<SaleItem> GetByName(string Term);

        SaleItem Create(SaleItem entity, string loggedInUser);

        SaleItem Update(SaleItem entity, string loggedInUser);

        bool Delete(SaleItem entity, string loggedInUser);

        bool validate(SaleItem entity);
    }
}
