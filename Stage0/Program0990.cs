namespace Stage0
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome0990();
            Welcome5487();
            Console.ReadKey();
        }
        static partial void Welcome5487();
        private static void Welcome0990()
        {
            Console.WriteLine("Enter your name:");
            string userName = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", userName);
        }
    }
}