using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IChallanItem
    {
        IQueryable<ChallanItem> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<ChallanItem> GetByName(string Term);

        ChallanItem Create(ChallanItem entity, string loggedInUser);

        ChallanItem Update(ChallanItem entity, string loggedInUser);

        bool Delete(ChallanItem entity, string loggedInUser);

        bool validate(ChallanItem entity);
    }
}
