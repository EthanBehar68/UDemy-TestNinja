using TestNinja.Mocking;

namespace TestNinja
{
    public  class Program   
    {
        // Need to change to console application
        // to run this program
        public static void Main()
        {
            // EXAMPLE OF METHOD PARAMETER DEPENDENCY INJECTION
            //var service = new VideoService();
            //var title = service.ReadVideoTitle(new FileReader());


            // EXAMPLE OF PROPERTY DEPENDENCY INJECTION
            //var service = new VideoService();
            //service.FileReader = new FileReader();
            //var title = service.ReadVideoTitle();

            // EXAMPLE OF CTOR DEPENDENCY INJECTION
            var service = new VideoService();
            var title = service.ReadVideoTitle();
        }
    }
}
