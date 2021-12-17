using System;
using System.Collections.Generic;
using System.Text;

namespace TouristСenterLibrary
{
    class ContextManager
    {
        public static ApplicationContext db { get; private set; }
        public ContextManager(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }
    }
}
