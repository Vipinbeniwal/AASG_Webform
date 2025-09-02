using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IFollowUp
    {
        IQueryable<FollowUp> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<FollowUp> GetByName(string Term);

        FollowUp Create(FollowUp entity, string loggedInUser);

        FollowUp Update(FollowUp entity, string loggedInUser);

        bool Delete(FollowUp entity, string loggedInUser);

        bool validate(FollowUp entity);
    }
}
