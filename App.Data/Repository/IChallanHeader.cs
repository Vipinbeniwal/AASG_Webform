using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IChallanHeader
    {
        IQueryable<ChallanHeader> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<ChallanHeader> GetByName(string Term);

        ChallanHeader Create(ChallanHeader entity, string loggedInUser);

        ChallanHeader Update(ChallanHeader entity, string loggedInUser);

        bool Delete(ChallanHeader entity, string loggedInUser);

        bool validate(ChallanHeader entity);

        IQueryable GetbyOrderNumber(string Id);
    }
}
