using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class Mapsp_ItemProcessDetail_Result
    {
        #region sp_ItemProcessDetail_Result Mapping

        public sp_ItemProcessDetail_Result Getsp_ItemProcessDetail_ResultBusinessObject(App.Data.sp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.sp_ItemProcessDetail_Result, sp_ItemProcessDetail_Result>();
            var sp_ItemProcessDetail_ResultBusinessObject = AutoMapper.Mapper.Map<App.Data.sp_ItemProcessDetail_Result, sp_ItemProcessDetail_Result>(sp_ItemProcessDetail_ResultDBObject);
            return sp_ItemProcessDetail_ResultBusinessObject;
        }

        public App.Data.sp_ItemProcessDetail_Result Getsp_ItemProcessDetail_ResultDatabaseObject(sp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<sp_ItemProcessDetail_Result, App.Data.sp_ItemProcessDetail_Result>();
            var sp_ItemProcessDetail_ResultDBObject = AutoMapper.Mapper.Map<sp_ItemProcessDetail_Result, App.Data.sp_ItemProcessDetail_Result>(sp_ItemProcessDetail_ResultBusinessObject);
            return sp_ItemProcessDetail_ResultDBObject;
        }

        #endregion
    }
}
