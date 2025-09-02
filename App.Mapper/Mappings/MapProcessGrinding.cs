using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapProcessGrinding
    {
        #region ProcessGrinding Mapping

        public App.BusinessModel.ProcessGrinding GetProcessGrindingBusinessObject(App.Data.ProcessGrinding ProcessGrindingDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ProcessGrinding, App.BusinessModel.ProcessGrinding>();
            var ProcessGrindingBusinessObject = AutoMapper.Mapper.Map<App.Data.ProcessGrinding, App.BusinessModel.ProcessGrinding>(ProcessGrindingDBObject);
            return ProcessGrindingBusinessObject;
        }

        public App.Data.ProcessGrinding GetProcessGrindingDatabaseObject(App.BusinessModel.ProcessGrinding ProcessGrindingBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ProcessGrinding, App.Data.ProcessGrinding>();
            var ProcessGrindingDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ProcessGrinding, App.Data.ProcessGrinding>(ProcessGrindingBusinessObject);
            return ProcessGrindingDBObject;
        }

        #endregion
    }
}
