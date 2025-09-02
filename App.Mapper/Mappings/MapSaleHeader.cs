using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapSaleHeader
    {
        #region SaleHeader Mapping

        public App.BusinessModel.SaleHeader GetSaleHeaderBusinessObject(App.Data.SaleHeader SaleHeaderDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.SaleHeader, App.BusinessModel.SaleHeader>();
            var SaleHeaderBusinessObject = AutoMapper.Mapper.Map<App.Data.SaleHeader, App.BusinessModel.SaleHeader>(SaleHeaderDBObject);
            return SaleHeaderBusinessObject;
        }

        public App.Data.SaleHeader GetSaleHeaderDatabaseObject(App.BusinessModel.SaleHeader SaleHeaderBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.SaleHeader, App.Data.SaleHeader>();
            var SaleHeaderDBObject = AutoMapper.Mapper.Map<App.BusinessModel.SaleHeader, App.Data.SaleHeader>(SaleHeaderBusinessObject);
            return SaleHeaderDBObject;
        }

        #endregion
    }
}
