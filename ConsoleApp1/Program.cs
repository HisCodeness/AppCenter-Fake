using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public static class MyApp
    {
        public static void Check()
        {
            AppCenter.Start(typeof(Analytics));
            Analytics.TrackEvent("BEAU GOSSE !");
        }
    }

}
