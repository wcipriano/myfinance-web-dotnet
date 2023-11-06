using System.Reflection;

namespace myfinance_web_netcore.Infrastructure
{
    public class AssemblyUtil
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {
            return new Assembly[] {
                //typeof(myfinance_web_netcore.Infrastructure.assass).ToString
                Assembly.Load("myfinance-web-netcore"),  //myfinance-web-netcore   myfinance_web_netcore
        };
        }
    }
}