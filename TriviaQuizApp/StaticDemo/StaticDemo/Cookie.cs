namespace StaticDemo
{
    internal class Cookie
    {
        //Data fields
        private int _size  = 1;
        private string _topping = "plain";
        
        //Class member: static members
        private static int _count = 0;

        //Constants
        public const string COMPANY = "CompSci";
        public const int YEAR = 2023;

        public Cookie(int size, string topping)
        {
            Size = size;
            Topping = topping;
            _count++; //or use the class name: Cookie._count++;
        }

        //Destructor - finalizer: decrease counter
        ~Cookie() 
        {
            _count--;
        }

        /* static constructor: called automatically to set static variables only
         * Does not accept any argument
         */
        static Cookie()
        {
            _count = 0;
            Shape = "Circle";
            Brand = "NA";
        }
        //Instance methods\Properties: can access instance members (data fields & methods) and static members 
        public int Size
        {
            get { return _size; }
            set 
            { 
                if(value >= 1 || value <= 5)
                    _size = value;
            }
        }

        public string Topping
        {
            get { return _topping; }
            set 
            { 
                if(!string.IsNullOrEmpty(value))
                    _topping = value;
            }
        }

        public override string ToString()
        {
            return $"Cookie size: {Size} - Topping:{Topping}";
        }

        public int GetSize()
        {
            return Size;
        }

        //Static methods: can access static members (variables & methods) only
        public static int GetCount()
        {
            return Cookie._count;
        }
        //A static member can be a property
        public static string Brand { get; set; }
        
        //Full property: note that all parts of the property (backing field, set and get) must be static
        private static string _shape;
        public static string Shape
        {
            get { return _shape; }
            set { _shape = value; }
        }

        /**
         *          WHO CAN ACCESS WHAT???
         * */

        //Instance Method
        public void NonStaticMethod()
        {
            //Can access non-static data members
            _size = 1;
            Size = 1;
            _topping = "Choc.";
            //Can access non-static method members
            GetSize();
            ToString();

            //Can access Static data & Method members
            _count = 0;
            GetCount();
            Brand = "NA";
            Shape = "NA";
        }

        public static void StaticMethod()
        {
            //can only access static data & methods
            _count = 0;
            GetCount();
            Brand = "ABC";
            Shape = "Star";

            //CANNOT access non static data (Cannot access instance data member)
            //_size = 0;
            //_topping = "none";
            
            //CANNOT access non static methods (Cannot access instance method member)
            //ToString();
        }

        //How to access an instance members from static methods: pass it as argument
        public static void StaticMethod(Cookie c)
        {
            _count = 0;
            GetCount();
            Brand = "ABC";
            Shape = "Star";
            //using argument object to access a non-static data or method
            c._size = 1;
            c.Size = 1;
            c._topping = "nothing";
            c.ToString();
        }
    }
}
