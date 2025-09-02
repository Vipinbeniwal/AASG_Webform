using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class MapvwPurchaseHeaderSupplierDetail
    {
        #region vwPurchaseHeaderSupplierDetail Mapping

        public App.BusinessModel.vwPurchaseHeaderSupplierDetail GetvwPurchaseHeaderDetailBusinessObject(App.Data.vwPurchaseHeaderSupplierDetail vwPurchaseHeaderDetailDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.vwPurchaseHeaderSupplierDetail, App.BusinessModel.vwPurchaseHeaderSupplierDetail>();
            var vwPurchaseHeaderDetailBusinessObject = AutoMapper.Mapper.Map<App.Data.vwPurchaseHeaderSupplierDetail, App.BusinessModel.vwPurchaseHeaderSupplierDetail > (vwPurchaseHeaderDetailDBObject);
            return vwPurchaseHeaderDetailBusinessObject;
        }

        public App.Data.vwPurchaseHeaderSupplierDetail GetvwPurchaseHeaderDetailDatabaseObject(App.BusinessModel.vwPurchaseHeaderSupplierDetail vwPurchaseHeaderDetailBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.vwPurchaseHeaderSupplierDetail, App.Data.vwPurchaseHeaderSupplierDetail>();
            var vwPurchaseHeaderDetailDBObject = AutoMapper.Mapper.Map<App.BusinessModel.vwPurchaseHeaderSupplierDetail, App.Data.vwPurchaseHeaderSupplierDetail>(vwPurchaseHeaderDetailBusinessObject);
            return vwPurchaseHeaderDetailDBObject;
        }

        #endregion
    }
}
