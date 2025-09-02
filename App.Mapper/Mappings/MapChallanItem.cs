using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapChallanItem
    {
        #region Activity Log Mapping

        public App.BusinessModel.ChallanItem GetChallanItemBusinessObject(App.Data.ChallanItem ChallanItemDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ChallanItem, App.BusinessModel.ChallanItem>();
            var ChallanItemBusinessObject = AutoMapper.Mapper.Map<App.Data.ChallanItem, App.BusinessModel.ChallanItem>(ChallanItemDBObject);
            return ChallanItemBusinessObject;
        }

        public App.Data.ChallanItem GetChallanItemDatabaseObject(App.BusinessModel.ChallanItem ChallanItemBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ChallanItem, App.Data.ChallanItem>();
            var ChallanItemDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ChallanItem, App.Data.ChallanItem>(ChallanItemBusinessObject);
            return ChallanItemDBObject;
        }

        #endregion
    }
}
