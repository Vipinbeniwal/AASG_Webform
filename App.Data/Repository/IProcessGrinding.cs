using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IProcessGrinding
    {
        IQueryable<ProcessGrinding> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<ProcessGrinding> GetByName(string Term);

        ProcessGrinding Create(ProcessGrinding entity, string loggedInUser);

        ProcessGrinding Update(ProcessGrinding entity, string loggedInUser);

        bool Delete(ProcessGrinding entity, string loggedInUser);

        bool validate(ProcessGrinding entity);
    }
}
