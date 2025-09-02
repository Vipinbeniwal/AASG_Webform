using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface Isp_tourdetail_Result
    {
        IQueryable<sp_tourdetail_Result> GetAll(int tour_master_id, int staff_master_id, string FromDate, string ToDate);

        IQueryable GetbyId(int Id);

        IQueryable<sp_tourdetail_Result> GetByName(string Term);

        sp_tourdetail_Result Create(sp_tourdetail_Result entity, string loggedInUser);

        sp_tourdetail_Result Update(sp_tourdetail_Result entity, string loggedInUser);

        bool Delete(sp_tourdetail_Result entity, string loggedInUser);

        bool validate(sp_tourdetail_Result entity);
    }
}
