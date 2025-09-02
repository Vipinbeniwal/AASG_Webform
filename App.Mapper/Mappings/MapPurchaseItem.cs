using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapPurchaseItem
    {
        #region PurchaseItem Mapping

        public App.BusinessModel.PurchaseItem GetPurchaseItemBusinessObject(App.Data.PurchaseItem PurchaseItemDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.PurchaseItem, App.BusinessModel.PurchaseItem>();
            var PurchaseItemBusinessObject = AutoMapper.Mapper.Map<App.Data.PurchaseItem, App.BusinessModel.PurchaseItem>(PurchaseItemDBObject);
            return PurchaseItemBusinessObject;
        }

        public App.Data.PurchaseItem GetPurchaseItemDatabaseObject(App.BusinessModel.PurchaseItem PurchaseItemBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.PurchaseItem, App.Data.PurchaseItem>();
            var PurchaseItemDBObject = AutoMapper.Mapper.Map<App.BusinessModel.PurchaseItem, App.Data.PurchaseItem>(PurchaseItemBusinessObject);
            return PurchaseItemDBObject;
        }

        #endregion
    }
}
