using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapChallanHeader
    {
        #region Activity Log Mapping

        public App.BusinessModel.ChallanHeader GetChallanHeaderBusinessObject(App.Data.ChallanHeader ChallanHeaderDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ChallanHeader, App.BusinessModel.ChallanHeader>();
            var ChallanHeaderBusinessObject = AutoMapper.Mapper.Map<App.Data.ChallanHeader, App.BusinessModel.ChallanHeader>(ChallanHeaderDBObject);
            return ChallanHeaderBusinessObject;
        }

        public App.Data.ChallanHeader GetChallanHeaderDatabaseObject(App.BusinessModel.ChallanHeader ChallanHeaderBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ChallanHeader, App.Data.ChallanHeader>();
            var ChallanHeaderDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ChallanHeader, App.Data.ChallanHeader>(ChallanHeaderBusinessObject);
            return ChallanHeaderDBObject;
        }

        #endregion
    }
}
