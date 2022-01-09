
namespace TouristСenterLibrary
{
    public class ContextManager
    {
        public static ApplicationContext db { get; private set; }
        public ContextManager(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }
    }
}
