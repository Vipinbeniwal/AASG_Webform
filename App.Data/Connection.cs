using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class Connection : IDisposable
    {
        private DBEntities context = null;

        public DBEntities ReturnContext()
        {
            if (context == null)
            {
                context = new DBEntities();
            }

            return context;
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
        }
    }
}
