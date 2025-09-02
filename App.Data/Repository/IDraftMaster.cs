using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IDraftMaster
    {
        IQueryable<DraftMaster> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<DraftMaster> GetByName(string Term);

        DraftMaster Create(DraftMaster entity, string loggedInUser);

        DraftMaster Update(DraftMaster entity, string loggedInUser);

        bool Delete(DraftMaster entity, string loggedInUser);

        bool validate(DraftMaster entity);
    }
}
