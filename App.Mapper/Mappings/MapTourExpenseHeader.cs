using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapTourExpenseHeader
    {
        #region TourExpenseHeader Mapping

        public TourExpenseHeader GetTourExpenseHeaderBusinessObject(App.Data.TourExpenseHeader TourExpenseHeaderDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.TourExpenseHeader, TourExpenseHeader>();
            var TourExpenseHeaderBusinessObject = AutoMapper.Mapper.Map<App.Data.TourExpenseHeader, TourExpenseHeader>(TourExpenseHeaderDBObject);
            return TourExpenseHeaderBusinessObject;
        }

        public App.Data.TourExpenseHeader GetTourExpenseHeaderDatabaseObject(TourExpenseHeader TourExpenseHeaderBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<TourExpenseHeader, App.Data.TourExpenseHeader>();
            var TourExpenseHeaderDBObject = AutoMapper.Mapper.Map<TourExpenseHeader, App.Data.TourExpenseHeader>(TourExpenseHeaderBusinessObject);
            return TourExpenseHeaderDBObject;
        }

        #endregion
    }
}
