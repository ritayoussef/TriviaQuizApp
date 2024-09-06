namespace MemoryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count;
            count = 10; //count cannot be used until a value is assigned to it.
            count++;
            int count2 = count; //copies the value of count to count2 in the run time stack

            //Create object without assignment
            new Employee();
            Console.WriteLine(new Employee(20).Address.PostalCode);

            //Create object with assignment
            Employee foo;
            //Initialize:
            //foo = null;
            foo = new Employee(10);
            foo.Salary = 10000;
            //Update address (object inside a class: pointer to an object from another object)
            foo.Address.StreetName = "St. Anne";
            foo.Address.PostalCode = "H8H1T1";

            Employee bundy = foo;//pointer to foo
            bundy.Salary = 2000;
            Employee tata = foo; //another pointer to foo
            tata = new Employee(123); //creating a new object and tata is pointing to it.
            tata = null; //removing pointer to the object created in the line above (the object will be cleaned by the garbage collector)
            bundy = null;

            //Examine how reference type variable behave
            Console.WriteLine("Foo Salary: " + foo.Salary.ToString("c"));
            Promote(foo);
            Console.WriteLine("Foo promoted Salary: " + foo.Salary.ToString("c"));

            //Examine how value type variable behave 
            Employee baz = new Employee(500);
            Console.WriteLine("baz Salary: " + baz.Salary.ToString("c"));
            Promote(baz.Salary);
            Console.WriteLine("baz promoted Salary: " + baz.Salary.ToString("c"));

            //Examine how reference type variable behave (change of the reference in the function)
            Employee bar = new Employee(1234);
            Console.WriteLine("bar Salary: " + bar.Salary.ToString("c"));
            PromoteV2(bar);
            Console.WriteLine("bar promoted(V2) Salary: " + bar.Salary.ToString("c"));

            //Examine how value type variable behave with and without the use of "ref" & "out" keywords
            double localVariable = 500;
            Promote(localVariable);
            Console.WriteLine("localVariable: " + localVariable);
            //Using value types as reference types
            Promote(ref localVariable);
            Console.WriteLine("Reference localVariable: " + localVariable);
            //Promote(ref foo.Salary); //cannot pass data saved on heap using ref or out


            //Strings are immutable: when changed a new reference is created. 
            //String will behave like value type variable even they are not.
            string name = "Alex";
            //string name1 = new string("Alex");
            //name = "ben";
            Console.WriteLine("name before: " + name);
            ChangeName(name);
            Console.WriteLine("name after: " + name);
            Console.WriteLine("name before (ref): " + name);
            ChangeName(ref name);
            Console.WriteLine("name after (ref): " + name);
            ref string x = ref name;
        }

        //Function to examine how reference type variable behave
        static void Promote(Employee e)
        {
            int increment = 100; //function local variable
            e.Salary += increment;
        }

        //Function to examine how value type variable behave
        static void Promote(double salary)
        {
            salary += 100;
        }

        //Function to examine how value type variable behave using the ref keyword
        static void Promote(ref double salary)
        {
            salary += 100;
        }

        //Function to examine how reference type variable behave when re-initialized in the function. 
        static void PromoteV2(Employee e)
        {
            e = new Employee(); //changing the pointer for the passed object.
            e.Salary += 100;
        }

        //Function to examine how a string variable behave
        static void ChangeName(string xyz)
        {
            Console.WriteLine(xyz);
            xyz = "new name";
            Console.WriteLine(xyz);
        }

        //Function to examine how a string variable behave using ref
        static void ChangeName(ref string xyz)
        {
            Console.WriteLine(xyz);
            xyz = "new name";
        }
    }

    /// <summary>
    /// Demo class: contains a basic data member (salary) and an object of Address class
    /// </summary>
    class Employee
    {
        private double salary;
        private Address address;

        public Employee(int salary = 0)
        {
            Salary = salary;
            //address = null;
            //Address object needs to be initialized to be used:
            address = new Address()
            {
                Number = 1234,
                StreetName = "St. Anne",
                PostalCode = "ABCD123"
            };

        }
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }
    }

    class Address
    {
        public int Number { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
    }
}