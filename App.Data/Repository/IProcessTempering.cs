using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IProcessTempering
    {
        IQueryable<ProcessTempering> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<ProcessTempering> GetByName(string Term);

        ProcessTempering Create(ProcessTempering entity, string loggedInUser);

        ProcessTempering Update(ProcessTempering entity, string loggedInUser);

        bool Delete(ProcessTempering entity, string loggedInUser);

        bool validate(ProcessTempering entity);
    }
}
