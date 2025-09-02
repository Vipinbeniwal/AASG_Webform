using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IUserRole
    {
        IQueryable<UserRole> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<UserRole> GetByName(string Term);

        UserRole Create(UserRole entity, string loggedInUser);

        UserRole Update(UserRole entity, string loggedInUser);

        bool Delete(UserRole entity, string loggedInUser);

        bool validate(UserRole entity);
    }
}
