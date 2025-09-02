using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IProcessWashing
    {
        IQueryable<ProcessWashing> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<ProcessWashing> GetByName(string Term);

        ProcessWashing Create(ProcessWashing entity, string loggedInUser);

        ProcessWashing Update(ProcessWashing entity, string loggedInUser);

        bool Delete(ProcessWashing entity, string loggedInUser);

        bool validate(ProcessWashing entity);
    }
}
