using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapSaleItem
    {
        #region SaleItem Mapping

        public App.BusinessModel.SaleItem GetSaleItemBusinessObject(App.Data.SaleItem SaleItemDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.SaleItem, App.BusinessModel.SaleItem>();
            var SaleItemBusinessObject = AutoMapper.Mapper.Map<App.Data.SaleItem, App.BusinessModel.SaleItem>(SaleItemDBObject);
            return SaleItemBusinessObject;
        }

        public App.Data.SaleItem GetSaleItemDatabaseObject(App.BusinessModel.SaleItem SaleItemBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.SaleItem, App.Data.SaleItem>();
            var SaleItemDBObject = AutoMapper.Mapper.Map<App.BusinessModel.SaleItem, App.Data.SaleItem>(SaleItemBusinessObject);
            return SaleItemDBObject;
        }

        #endregion
    }
}
