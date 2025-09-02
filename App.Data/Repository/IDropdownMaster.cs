using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IDropdownMaster
    {
        IQueryable<DropdownMaster> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<DropdownMaster> GetByName(string Term);

        DropdownMaster Create(DropdownMaster entity, string loggedInUser);

        DropdownMaster Update(DropdownMaster entity, string loggedInUser);

        bool Delete(DropdownMaster entity, string loggedInUser);

        bool validate(DropdownMaster entity);
    }
}
