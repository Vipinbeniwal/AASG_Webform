using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IPartyMaster
    {
        IQueryable<PartyMaster> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<PartyMaster> GetByName(string Term);

        PartyMaster Create(PartyMaster entity, string loggedInUser);

        PartyMaster Update(PartyMaster entity, string loggedInUser);

        bool Delete(PartyMaster entity, string loggedInUser);

        bool validate(PartyMaster entity);
    }
}
