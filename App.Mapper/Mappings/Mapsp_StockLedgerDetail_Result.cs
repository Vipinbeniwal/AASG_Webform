using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class Mapsp_StockLedgerDetail_Result
    {
        #region sp_StockLedgerDetail_Result Mapping

        public sp_StockLedgerDetail_Result Getsp_StockLedgerDetail_ResultBusinessObject(App.Data.sp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.sp_StockLedgerDetail_Result, sp_StockLedgerDetail_Result>();
            var sp_StockLedgerDetail_ResultBusinessObject = AutoMapper.Mapper.Map<App.Data.sp_StockLedgerDetail_Result, sp_StockLedgerDetail_Result>(sp_StockLedgerDetail_ResultDBObject);
            return sp_StockLedgerDetail_ResultBusinessObject;
        }

        public App.Data.sp_StockLedgerDetail_Result Getsp_StockLedgerDetail_ResultDatabaseObject(sp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<sp_StockLedgerDetail_Result, App.Data.sp_StockLedgerDetail_Result>();
            var sp_StockLedgerDetail_ResultDBObject = AutoMapper.Mapper.Map<sp_StockLedgerDetail_Result, App.Data.sp_StockLedgerDetail_Result>(sp_StockLedgerDetail_ResultBusinessObject);
            return sp_StockLedgerDetail_ResultDBObject;
        }

        #endregion
    }
}
