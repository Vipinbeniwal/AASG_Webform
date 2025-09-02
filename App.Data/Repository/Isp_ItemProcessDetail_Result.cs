using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface Isp_ItemProcessDetail_Result
    {
        IQueryable<sp_ItemProcessDetail_Result> GetAll(string batch_number, string ItemMasterId);

        IQueryable GetbyId(int Id);

        IQueryable<sp_ItemProcessDetail_Result> GetByName(string Term);

        sp_ItemProcessDetail_Result Create(sp_ItemProcessDetail_Result entity, string loggedInUser);

        sp_ItemProcessDetail_Result Update(sp_ItemProcessDetail_Result entity, string loggedInUser);

        bool Delete(sp_ItemProcessDetail_Result entity, string loggedInUser);

        bool validate(sp_ItemProcessDetail_Result entity);
    }
}
