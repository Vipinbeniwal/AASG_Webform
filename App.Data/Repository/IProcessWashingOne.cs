using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IProcessWashingOne
    {
        IQueryable<ProcessWashingOne> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<ProcessWashingOne> GetByName(string Term);

        ProcessWashingOne Create(ProcessWashingOne entity, string loggedInUser);

        ProcessWashingOne Update(ProcessWashingOne entity, string loggedInUser);

        bool Delete(ProcessWashingOne entity, string loggedInUser);

        bool validate(ProcessWashingOne entity);
    }
}
