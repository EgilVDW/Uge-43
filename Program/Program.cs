using Project;
    
namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            IRepository uR = new APIRepository();
            //APIRepository apiRepository = new APIRepository();
        }
    }
}