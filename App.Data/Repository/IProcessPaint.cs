using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IProcessPaint
    {
        IQueryable<ProcessPaint> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<ProcessPaint> GetByName(string Term);

        ProcessPaint Create(ProcessPaint entity, string loggedInUser);

        ProcessPaint Update(ProcessPaint entity, string loggedInUser);

        bool Delete(ProcessPaint entity, string loggedInUser);

        bool validate(ProcessPaint entity);
    }
}
