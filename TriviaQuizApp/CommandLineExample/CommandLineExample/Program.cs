namespace CommandLineExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Number of Arguments {args.Length}");
            //Console.WriteLine(args.Length);
            //foreach (string arg in args)
            //{
            //    Console.WriteLine(arg);
            //}
            if (args.Length == 0)
            {
                Console.WriteLine("Hello choose option 1 or 2 from the menu.****");
                string choice = Console.ReadLine();
                if (choice == "1")
                    DoTask1();
                else if (choice == "2")
                    DoTask2();
                else
                    Console.WriteLine("Invalid menu option");
            }
            else if(args.Length == 1)
            {
                switch (args[0])
                {
                    case "1":
                        DoTask1();
                        break;
                    case "2":
                        DoTask2(); 
                        break;
                    default:
                        Console.WriteLine(PrintArgementExample());
                        break;
                }
            }
            else
            {
                Console.WriteLine(PrintArgementExample());
            }
            
        }

        static void DoTask1()
        {
            Console.WriteLine("Performing Task 1... ");
        }

        static void DoTask2()
        {
            Console.WriteLine("Performing Task 2....");
        }

        static string PrintArgementExample()
        {
            return "Error invalid arguments: valid value are 1 or 2\nExample\nCommandLineExample.exe 1 ";
        }
    }
}