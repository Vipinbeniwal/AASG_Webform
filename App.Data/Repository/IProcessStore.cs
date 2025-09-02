using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IProcessStore
    {
        IQueryable<ProcessStore> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<ProcessStore> GetByName(string Term);

        ProcessStore Create(ProcessStore entity, string loggedInUser);

        ProcessStore Update(ProcessStore entity, string loggedInUser);

        bool Delete(ProcessStore entity, string loggedInUser);

        bool validate(ProcessStore entity);
    }
}
