using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapStockIssuanceItem
    {
        #region StockIssuanceItem Mapping

        public App.BusinessModel.StockIssuanceItem GetStockIssuanceItemBusinessObject(App.Data.StockIssuanceItem StockIssuanceItemDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.StockIssuanceItem, App.BusinessModel.StockIssuanceItem>();
            var StockIssuanceItemBusinessObject = AutoMapper.Mapper.Map<App.Data.StockIssuanceItem, App.BusinessModel.StockIssuanceItem>(StockIssuanceItemDBObject);
            return StockIssuanceItemBusinessObject;
        }

        public App.Data.StockIssuanceItem GetStockIssuanceItemDatabaseObject(App.BusinessModel.StockIssuanceItem StockIssuanceItemBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.StockIssuanceItem, App.Data.StockIssuanceItem>();
            var StockIssuanceItemDBObject = AutoMapper.Mapper.Map<App.BusinessModel.StockIssuanceItem, App.Data.StockIssuanceItem>(StockIssuanceItemBusinessObject);
            return StockIssuanceItemDBObject;
        }

        #endregion
    }
}
