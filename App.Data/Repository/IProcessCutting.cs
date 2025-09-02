using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IProcessCutting
    {
        IQueryable<ProcessCutting> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<ProcessCutting> GetByName(string Term);

        ProcessCutting Create(ProcessCutting entity, string loggedInUser);

        ProcessCutting Update(ProcessCutting entity, string loggedInUser);

        bool Delete(ProcessCutting entity, string loggedInUser);

        bool validate(ProcessCutting entity);
    }
}
