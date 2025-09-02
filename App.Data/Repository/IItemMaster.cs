using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IItemMaster
    {
        IQueryable<ItemMaster> GetAll();
        IQueryable<vwItemListWithModelAndGlassColor> GetAllItemListWithModelAndGlassColor();
        IQueryable GetbyId(int Id);

        IQueryable<ItemMaster> GetByName(string Term);

        ItemMaster Create(ItemMaster entity, string loggedInUser);

        ItemMaster Update(ItemMaster entity, string loggedInUser);

        bool Delete(ItemMaster entity, string loggedInUser);

        bool validate(ItemMaster entity);
    }
}
