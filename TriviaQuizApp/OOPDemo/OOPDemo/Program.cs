namespace OOPDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(); //uses the default value of the id argument.
            Student student2 = new Student(100); //uses the passed id argument.

            //Uses the second constructor, which will call the first constructor internally
            Student student3 = new Student(100,"Alex","Thomas");
            
            Student student4 = new Student("Alex","Thomas");
            Student student5 = new Student(100, 2.0);
            Student student6 = new Student(500, "Dan", "Ben",22);

            student6.FirstName = "Alex";
            //student6.ID = 10;
            Console.WriteLine(student6.FirstName);


            //student._grades[0] = 100;

            //double[] xyz;
            //xyz[0] = 100;

            Student newstudent = new Student()
            {
                FirstName = "Thomas",
                LastName = "Sally",

            };


        }

        
    }

    class MyClass
    {

    }

    class MyClass2
    {

    }
}