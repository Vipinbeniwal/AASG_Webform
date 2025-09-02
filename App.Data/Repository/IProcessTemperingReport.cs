using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IProcessTemperingReport
    {
        IQueryable<ProcessTemperingReport> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<ProcessTemperingReport> GetByName(string Term);

        ProcessTemperingReport Create(ProcessTemperingReport entity, string loggedInUser);

        ProcessTemperingReport Update(ProcessTemperingReport entity, string loggedInUser);
        ProcessTemperingReport UpdateByProcessTemperingId(ProcessTemperingReport entity, string loggedInUser);

        bool Delete(ProcessTemperingReport entity, string loggedInUser);

        bool validate(ProcessTemperingReport entity);
    }
}
