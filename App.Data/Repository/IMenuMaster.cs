using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IMenuMaster
    {
        IQueryable<MenuMaster> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<MenuMaster> GetByName(string Term);

        MenuMaster Create(MenuMaster entity, string loggedInUser);

        MenuMaster Update(MenuMaster entity, string loggedInUser);

        bool Delete(MenuMaster entity, string loggedInUser);

        bool validate(MenuMaster entity);
    }
}
