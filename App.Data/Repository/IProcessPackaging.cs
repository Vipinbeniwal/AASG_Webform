using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IProcessPackaging
    {
        IQueryable<ProcessPackaging> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<ProcessPackaging> GetByName(string Term);

        ProcessPackaging Create(ProcessPackaging entity, string loggedInUser);

        ProcessPackaging Update(ProcessPackaging entity, string loggedInUser);

        bool Delete(ProcessPackaging entity, string loggedInUser);

        bool validate(ProcessPackaging entity);
    }
}
