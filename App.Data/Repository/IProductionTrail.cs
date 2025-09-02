using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IProductionTrail
    {
        IQueryable<ProductionTrail> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<ProductionTrail> GetByName(string Term);

        ProductionTrail Create(ProductionTrail entity, string loggedInUser);

        ProductionTrail Update(ProductionTrail entity, string loggedInUser);

        bool Delete(ProductionTrail entity, string loggedInUser);

        bool validate(ProductionTrail entity);
    }
}
