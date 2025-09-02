using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IDrawingMaster
    {
        IQueryable<DrawingMaster> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<DrawingMaster> GetByName(string Term);

        DrawingMaster Create(DrawingMaster entity, string loggedInUser);

        DrawingMaster Update(DrawingMaster entity, string loggedInUser);

        bool Delete(DrawingMaster entity, string loggedInUser);

        bool validate(DrawingMaster entity);
    }
}
