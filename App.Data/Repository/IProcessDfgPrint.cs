using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IProcessDfgPrint
    {
        IQueryable<ProcessDfgPrint> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<ProcessDfgPrint> GetByName(string Term);

        ProcessDfgPrint Create(ProcessDfgPrint entity, string loggedInUser);

        ProcessDfgPrint Update(ProcessDfgPrint entity, string loggedInUser);

        bool Delete(ProcessDfgPrint entity, string loggedInUser);

        bool validate(ProcessDfgPrint entity);
    }
}
