using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class Mapsp_tourdetail_Result
    {
        #region sp_tourdetail_Result Mapping

        public sp_tourdetail_Result Getsp_tourdetail_ResultBusinessObject(App.Data.sp_tourdetail_Result sp_tourdetail_ResultDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.sp_tourdetail_Result, sp_tourdetail_Result>();
            var sp_tourdetail_ResultBusinessObject = AutoMapper.Mapper.Map<App.Data.sp_tourdetail_Result, sp_tourdetail_Result>(sp_tourdetail_ResultDBObject);
            return sp_tourdetail_ResultBusinessObject;
        }

        public App.Data.sp_tourdetail_Result Getsp_tourdetail_ResultDatabaseObject(sp_tourdetail_Result sp_tourdetail_ResultBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<sp_tourdetail_Result, App.Data.sp_tourdetail_Result>();
            var sp_tourdetail_ResultDBObject = AutoMapper.Mapper.Map<sp_tourdetail_Result, App.Data.sp_tourdetail_Result>(sp_tourdetail_ResultBusinessObject);
            return sp_tourdetail_ResultDBObject;
        }

        #endregion
    }
}
