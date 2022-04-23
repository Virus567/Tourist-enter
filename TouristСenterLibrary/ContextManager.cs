
using Npgsql;

namespace TouristСenterLibrary
{
    public class ContextManager
    {
        public static ApplicationContext db { get; private set; }
        public static NpgsqlConnection npgsql { get; private set; }
        public ContextManager(ApplicationContext applicationContext)
        {
            db = applicationContext;
            npgsql = new NpgsqlConnection(ApplicationContext.ConnectionString);
            npgsql.Open();
        }
    }
}
