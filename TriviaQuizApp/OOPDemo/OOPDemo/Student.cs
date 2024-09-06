using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    /// <summary>
    /// Class used for demo.
    /// Created in a separate file: better practice to keep our project clean.
    /// </summary>
    internal class Student
    {
        /**
         * Data Members:
         * 
         *  - Assignment to default values: 
         *      - Can take place in the constructor.
         *      - Can take place while declaration if these value are not passed from the user for the program.
         *      - Can use default values in the constructor passed variables as well.
         *      
         *  - Object, Collections & Arrays data members require initialization using the new operator. Done on 
         *      - Declaration. (or)
         *      - In the constructor.
         *      
         */
        //Basic (string is not basic but added here (will be discussed later))
        private int _id;
        private string _program;
        private string _firstName, _lastName;
        private int _age;

        //Complex: Arrays, lists objects: require initialization
        private double[] _grades; //needs initialization: = new double[10]; 
        //One option is to do initialization on declaration

        //Constants
        private const double TAX_RATE = 1.15;
        private readonly int NUMBER_OF_COURSES;

        //Method Members

        /**
         * Constructors: create different constructors if needed.
         * 
         * A constructor with no arguments is known as default constructor.
         * You will loose the option to use a default constructor once there is a constructor with arguments
         * To be able to use a default constructor, either use a default value for arguments or create an empty constructor
         * 
         * code snippet: ctor to create a constructor
         */
        public Student(int id = 999) //an argument with default value
        {
            //this._id = id; //this keyword is used to identify private data field from passed argument.
            //SetID(id); //Validate using the setter.
            ID = id; // Validate using the property Set 
            NUMBER_OF_COURSES = 10;
            _grades = new double[NUMBER_OF_COURSES];
        }

        //Constructor with three parameters
        public Student(int id, string firstName, string lastName)
            : this(id)
        {
            //_firstName = firstName;
            //_lastName = lastName;

            //Validation using the Setter method
            //SetFirstName(firstName);
            //SetLastName(lastName);

            //Validation using the property Set
            FirstName = firstName;
            LastName = lastName;
        }

        public Student(string firstName, string lastName)
            : this() //will use the default value of 999 for ID
        {
            //_firstName = firstName;
            //_lastName = lastName;
            FirstName = firstName;
            LastName = lastName;
        }

        public Student(int id_x, string firstName_y, string lastName_w, int age)
            : this(id_x, firstName_y, lastName_w)
        {
            _age = age;
        }

        //Destructor: will be called automatically when the object is out of scope
        ~Student()
        {
            //Mainly used to release resources
        }

        /**
         * Getter & Setter methods: 
         *  - Used to retrieve and changes values of private data fields.
         *  - Not commonly used in .NET as we use Properties (discussed below)
         */

        /* Getters
         *  - Never change a value of backing field in a setter.
         *  - Always have a public access modifier
         *  - Note the use of the verb Get in the name of the method.
         */
        public int GetID()
        {
            return _id;
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        /* Setters
         *  - Note the use of the verb set in the name of the method.
         *  - Validation of private field takes place in setters.
         */
        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException("First name cannot be empty", "firstName");

            _firstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentException("...");
            _lastName = lastName;
        }

        //Note the use of a private Setter: used for validation only
        private void SetID(int id)
        {
            if (id < 100) //assume that the ID has to have a minimum of 3 digits
                throw new ArgumentException("ID must be 3 digits", "id");
            _id = id;
        }
        //Setter and getter at the same time: set the value and return it.
        public int SetAge(int age)
        {
            if (age <= 16)
                throw new ArgumentException("Age must be at least 16", "age");
            return _age = age;
        }

        public int SetAge(DateTime age)
        {
            if (DateTime.Today.Year - age.Year <= 16)
                throw new ArgumentException("Age must be at least 16", "age");
            return _age = age.Year;
        }

        //Behavior Methods

        //Special Type of getter that depends on multiple backing fields
        public string GetFullName()
        {
            return $"{_lastName}, {_firstName}";
        }

        public double GetHighestGrade()
        {
            double max = _grades[0];
            for (int i = 1; i < _grades.Length; i++)
            {
                if (max < _grades[i])
                    max = _grades[i];
            }
            return max;
        }

        //Behavior method
        public double CalculateTax(double income)
        {
            return income * (TAX_RATE - 1);
        }

        //Behavior Method
        public string DisplayDetails()
        {
            return string.Format("ID {0} - Name {1}", _id, GetFullName());
        }

        /**
         * Properties (a .Net feature):
         * 
         * Auto-implemented Properties in C# and any other .Net language will create a private field (under the hood) that will support the public field.
         * Properties facilitate creating setters and getters.
         * 
         * How to check that a private field is created? (After building the project) 
         * 
         * We can use a .NET Disassembler. .Net always installs one, usually installed under: (for version 4.6.1 change path as per the version installed on your system)
         * C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\ildasm.exe
         * Locate the DLL file created by the project and open it using the ildasm.exe, examine the defined classes.
         * All public properties will have private data field backing it.
         */
        //Auto-implemented property (or short properties)
        public int IQ { get; set; }
        public string Address { get; set; }

        /**
         * Full Property includes:
         *  - A private data field (backing field)
         *  - Public property with same data type of the private backing data field.
         *  - get code block: returns the private backing field.
         *  - set code block: uses value is a keyword for the passed argument to change the value of the backing field.
         *      Validation takes place in the Set block.
         */
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set //keyword: value
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("...");
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("...");
                _lastName = value;
            }
        }

        public string Program
        {
            get
            {
                return _program;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _program = value;
                else
                    _program = "TBA"; ////We do not alway need to throw an exception. It depends on the requirements\logic. 
            }
        }
        //Read only property: with a private setter 
        public int ID
        {
            get
            {
                return _id;
            }
            private set //note the private access modifier
            {
                SetID(value);
            }
        }
        //Calculated Property: has a get block only (which is a read only by default)
        public string FullName
        {
            get { return _firstName + " " + _lastName; }
        }

        //Calculated Property: has a get block only
        public int Scores
        {
            get
            {
                int sum = 0;
                foreach (int score in _grades)
                    sum += score;

                return sum;
            }
        }




    }
}
