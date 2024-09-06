using System.Reflection.Metadata;

namespace StaticDemo
{
    internal class Program
    {
        //Program class variables
        private static int globalVariable = 0;
        private int instanceVariable = 10;

        static void Main(string[] args)
        {

            Console.WriteLine("Hello, Static Cookie Factory");

            #region Static members in a class
            Console.WriteLine("Hello Static members in Non-Static Classes!");
            
            Console.WriteLine($"Cookie start = {Cookie.GetCount()}");
            //Changing my cookie company settings :) using static Properties
            Cookie.Brand = "SectionII";
            Cookie.Shape = "Star";
            Console.WriteLine($"Band name: {Cookie.Brand}");

            //Create some yummy cookies objects 
            Cookie aref = new Cookie(2, "Chocolate Chip");
            Cookie lucas = new Cookie(5, "Nuts");
            Cookie taryn = new Cookie(5, "Sprinkles");
            Cookie david = new Cookie(4, "Peanut Butter");

            //Display my cookies
            Console.WriteLine(aref);
            Console.WriteLine(lucas);
            Console.WriteLine(taryn);
            Console.WriteLine(david);

            //What is the cookies count now?
            Console.WriteLine($"Cookie Midway = {Cookie.GetCount()}");

            //Create a cookie inside a method. Cookie object will not be returned (no pointer to it)
            CreatDummyCookie();
            CreatDummyCookie();
            CreatDummyCookie();
            Console.WriteLine($"Cookie Count after CreatDummyCookie # {Cookie.GetCount()}");

            // Force the garbage collector to look for objects that need to be released from memory
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

            Console.WriteLine($"Cookie final = {Cookie.GetCount()}");
            //To access instance data\method members in a static method, pass an instance
            Cookie.StaticMethod(aref);
            #endregion

            #region constants
            //C# considers constant variables as static members
            Console.WriteLine("Constants are considered static members");
            Console.WriteLine($"Cookie Company: {Cookie.COMPANY}");
            Console.WriteLine($"Cookie Company was established in {Cookie.YEAR}");
            #endregion

            #region static classes
            //We cannot create an object of a static class.
            //TaxCalculator t = new TaxCalculator();
            Console.WriteLine("\n\nHello Static Classes!");
            double alexIncome = 20000;
            Console.WriteLine($"Alex's income: {alexIncome.ToString("c")}");
            Console.WriteLine($"Due taxes: {TaxCalculator.CalculateTaxes(alexIncome).ToString("c")}");

            //Built-in Static Classes: Console, Math, File.. and many other
            //Console c = new Console(); //Will give an error.
            //Always use the class name to access member of static classes. Examples:
            double number = Math.Floor(123.456);
            File.Exists("FileName.txt");
            #endregion

            #region Program class
            //Program static members
            Program.globalVariable = 10;    //Program has access to golbalVariable 
            globalVariable = 20;            //No need to use the class name Program
            Program.ClassMethod(); //or just
            ClassMethod();

            Program p = new Program(); //you can create an object of the program class if needed.
            p.instanceVariable = 10; //p has access to instanceVariable only 
            p.InstanceMethod(); //InstanceMethod
            #endregion

        }


        // A method to demonstrate an object created and then release from the HEAP
        static void CreatDummyCookie()
        {
            Cookie temp = new Cookie(3, "Plain");
            Console.WriteLine("Temp cookie created " + Cookie.GetCount());
        }

        static void ClassMethod()
        {
            Console.WriteLine($"This method can access the global variable only: {globalVariable}");
            //Can only access members marked as static
            //Console.WriteLine($"Cannot access non-static members: {instanceVariable}"); //ERROR
        }

        void InstanceMethod()
        {
            Console.WriteLine($"This method needs a Program instance to run.\n" +
                $"Can access both static: {globalVariable} and non-static members: {instanceVariable}");
        }
    }
}