using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IProductionPlanning
    {
        IQueryable<ProductionPlanning> GetAll();
        IQueryable GetbyId(int Id);

        IQueryable<ProductionPlanning> GetByName(string Term);

        ProductionPlanning Create(ProductionPlanning entity, string loggedInUser);

        ProductionPlanning Update(ProductionPlanning entity, string loggedInUser);

        bool Delete(ProductionPlanning entity, string loggedInUser);

        bool validate(ProductionPlanning entity);
    }
}
