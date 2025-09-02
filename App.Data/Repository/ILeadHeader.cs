using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface ILeadHeader
    {
        IQueryable<LeadHeader> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<LeadHeader> GetByName(string Term);

        LeadHeader Create(LeadHeader entity, string loggedInUser);

        LeadHeader Update(LeadHeader entity, string loggedInUser);

        bool Delete(LeadHeader entity, string loggedInUser);

        bool validate(LeadHeader entity);
    }
}
