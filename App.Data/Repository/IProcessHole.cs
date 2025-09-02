using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IProcessHole
    {
        IQueryable<ProcessHole> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<ProcessHole> GetByName(string Term);

        ProcessHole Create(ProcessHole entity, string loggedInUser);

        ProcessHole Update(ProcessHole entity, string loggedInUser);

        bool Delete(ProcessHole entity, string loggedInUser);

        bool validate(ProcessHole entity);
    }
}
