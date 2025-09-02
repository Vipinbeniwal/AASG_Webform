using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IProduction
    {
        IQueryable<Production> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable GetProductionDetailsbyItemMasterId(int Id);

        IQueryable<Production> GetByName(string Term);

        Production Create(Production entity, string loggedInUser);

        Production Update(Production entity, string loggedInUser);

        bool Delete(Production entity, string loggedInUser);

        bool validate(Production entity);
    }
}
