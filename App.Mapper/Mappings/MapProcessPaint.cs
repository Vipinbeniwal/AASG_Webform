using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapProcessPaint
    {
        #region ProcessPaint Mapping

        public App.BusinessModel.ProcessPaint GetProcessPaintBusinessObject(App.Data.ProcessPaint ProcessPaintDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ProcessPaint, App.BusinessModel.ProcessPaint>();
            var ProcessPaintBusinessObject = AutoMapper.Mapper.Map<App.Data.ProcessPaint, App.BusinessModel.ProcessPaint>(ProcessPaintDBObject);
            return ProcessPaintBusinessObject;
        }

        public App.Data.ProcessPaint GetProcessPaintDatabaseObject(App.BusinessModel.ProcessPaint ProcessPaintBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ProcessPaint, App.Data.ProcessPaint>();
            var ProcessPaintDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ProcessPaint, App.Data.ProcessPaint>(ProcessPaintBusinessObject);
            return ProcessPaintDBObject;
        }

        #endregion
    }
}
