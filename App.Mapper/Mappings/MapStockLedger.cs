using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapStockLedger
    {
        #region StockLedger Mapping

        public App.BusinessModel.StockLedger GetStockLedgerBusinessObject(App.Data.StockLedger StockLedgerDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.StockLedger, App.BusinessModel.StockLedger>();
            var StockLedgerBusinessObject = AutoMapper.Mapper.Map<App.Data.StockLedger, App.BusinessModel.StockLedger>(StockLedgerDBObject);
            return StockLedgerBusinessObject;
        }

        public App.Data.StockLedger GetStockLedgerDatabaseObject(App.BusinessModel.StockLedger StockLedgerBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.StockLedger, App.Data.StockLedger>();
            var StockLedgerDBObject = AutoMapper.Mapper.Map<App.BusinessModel.StockLedger, App.Data.StockLedger>(StockLedgerBusinessObject);
            return StockLedgerDBObject;
        }

        #endregion
    }
}
