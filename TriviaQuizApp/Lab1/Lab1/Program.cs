using System.Diagnostics;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Exercise 7
            //Call garbage collector to before starting the method to avoid it being called within
            System.GC.Collect();

            //Sample input - variables
            string[] messages = { "Alex", "ben", "Dan", "Phil" };

            /* TEST Stopwatch with Exercise 2 
             */
            int number = 30;
            int power = 1000000000;
            long value1;
            double value;
            //Create and Start timer 
            Stopwatch timer = Stopwatch.StartNew();
            /* Note: To examine class methods, press on Ctrl button then hover mouse over class name, a link will be 
             * provided, click on it to go the definition page.
             */

            //Call function
            value1 = PowerV1(number, power);
            //Stop timer
            timer.Stop();
            //Display time
            Console.WriteLine($"Power V1 output is {value1}.");
            Console.WriteLine($"Power V1 run time is: {timer.Elapsed}, Milliseconds # {timer.ElapsedMilliseconds} ");


            //or restart from 0 to test the second version
            timer.Restart();

            value = PowerV2(number, power);
            timer.Stop();
            Console.WriteLine($"Power V2 output is {value}.");
            Console.WriteLine($"Power V2 run time is: {timer.Elapsed}, Milliseconds # {timer.ElapsedMilliseconds} ");


            /* Additional functionalities for a Stopwatch object  */
            //Reset timer to 0
            //timer.Reset();
        }

        #region Exercise 1

        /** Exercise# 1.A
         * 1- Operations # 1
         * 2- O(1)
         * 3- Best case:  Not Applicable
         *    Worst case: NA
         */
        public static void LogMessagesV1(string[] messages)
        {
            Console.WriteLine(messages[0]); // 1 operation
        }

        /** Exercise# 1.B
         * 1- Ops # 2 
         * 2- O(1)
         * 3- Not applicable but if we analyze number of operations: 
         *    Best case: do 1 operation / Worst case : 2 operations
         */
        public static void LogMessagesV2(string[] messages)
        {
            if (messages.Length >= 1) //1 +
                Console.WriteLine(messages[0]); //1
        }

        /** Exercise# 1.C
         * 1- Ops# 1+1+1 = 3 
         * 2- O(1)
         * 3- NA / Best: length < 2 | Worst: length 2 or more
         */
        public static void LogMessagesV3(string[] messages)
        {
            if (messages.Length >= 2) // 1 +
            {
                Console.WriteLine(messages[0]); // 1 + 
                Console.WriteLine(messages[1]); // 1 
            }
        }

        /** Exercise# 1.D
         * 1- Ops # n*1 = n
         * 2- O(n)
         * 3- NA: Best: array empty, 1 operation >> O(1) | Worst: array has items in it. >>O(n)
         */
        public static void PrintArrayV1(string[] names)
        {
            for (int i = 0; i < names.Length; i++) //n* 
            {
                Console.WriteLine(names[i]); //1
            }
        }

        /** Exercise# 1.E
         * 1- Ops # 1 + (n*1) + 1 = n + 2
         * 2- O(n)
         * 3- NA: Best: array empty: 3 operations >>O(1) | Worst: array has items in it. >>O(n) 
         */
        public static void PrintArrayV2(string[] names)
        {
            Console.WriteLine("*** HEADER ***"); //1 + 

            for (int i = 0; i < names.Length; i++) //n * 
            {
                Console.WriteLine(names[i]); // 1
            }

            Console.WriteLine("*** FOOTER ***"); //1
        }

        /** Exercise# 1.F
         * 1- Ops # n + n = 2n 
         * 2- O(n)
         * 3- NA: array empty, 2 operations >>O(1)| Worst: array has items in it.>>O(n)
         */
        public static void PrintArrayV3(string[] names)
        {
            for (int i = 0; i < names.Length; i++) //n * 1
            {
                Console.WriteLine(names[i]); //Printing names
            }

            for (int i = 0; i < names.Length; i++) //n * 1
            {
                Console.WriteLine(names[i].Length); //Printing length of each name
            }
        }

        /** Exercise# 1.G
         * 1- Ops # n + m (both are linear)
         * 2- O(n) n refers to the larger size array
         * 3- NA: same as stated before.
         */
        public static void PrintReport(string[] names, int[] IDs)
        {
            for (int i = 0; i < names.Length; i++) //n*
            {
                Console.WriteLine(names[i]); //1
            }
            
            //+

            for (int i = 0; i < IDs.Length; i++) //m*
            {
                Console.WriteLine(IDs[i]);//1
            }

            //NO NESTING: we cannot assume that the 2 arrays have the same size (no guaranty)
        }

        #endregion

        #region Exercise 2 

        /** Exercise# 2.A
         * 1- Ops # n*1
         * 2- O(n) 
         * 3- NA: best case size = 0 >> O(1) , worst case >> O(n)
         */
        public static void PrintCoordinatesV1(int size)
        {
            for (int x = 0; x < size; x++) //n * 
                Console.Write("{0}  ", x); //1
        }

        /** Exercise# 2.B
         * 1- Ops # n* (n*1 + 1) = n^2 + n
         * 2- O(n^2) 
         * 3- NA: same note 
         */
        public static void PrintCoordinatesV2(int size)
        {
            for (int x = 0; x < size; x++) //n * 
            {
                for (int y = 0; y < size; y++) // n
                {
                    Console.Write("{0},{1}  ", x, y); //1
                }
                // +
                Console.WriteLine(); //just move to the next line //1 
            }
        }

        /** Exercise# 2.C
         * 1- Ops # n*1 + 1 + n* (n*1 + 1) = n^2 + 2n + 1
         * 2- O(n^2) 
         * 3- NA: same note 
         */
        public static void PrintCoordinatesV3(int size)
        {
            for (int x = 0; x < size; x++) //n * 
                Console.Write("{0}  ", x); //1
            //+
            Console.WriteLine(); // create new line. //1
            //+
            for (int x = 0; x < size; x++) //n * 
            {
                for (int y = 0; y < size; y++) // n
                {
                    Console.Write("{0},{1}  ", x, y); //1
                }
                Console.WriteLine(); //just move to the next line //1
            }
        }

        /** Exercise# 2.D
         * 1- Ops # n* n* (n* 1 + 1) = n^2 * (n+1)  = n^3 + n^2 
         * 2- O(n^3) 
         * 3- NA: same note 
         */
        public static void PrintCoordinatesV4(int size)
        {
            for (int x = 0; x < size; x++) //n * 
            {
                for (int y = 0; y < size; y++) // n * 
                {
                    for (int z = 0; z < size; z++) //n *
                    {
                        Console.Write("{0},{1},{2}  ", x, y, z); //1 
                    }
                    Console.WriteLine(); //just move to the next line //1
                }

            }
        }

        #endregion

        #region Exercise 3

        /**
         * 1- Ops # 1+ n*2 + 1 = 2n + 2
         * 2- O(n) 
         * 3- Best case: value is found at the index 0 (O(1))
         *    Worst case: value not found in array or value is at the end of the array  (O(n))
         */
        public static int Search(int[] numbers, int key)
        {
            const int NOT_FOUND = -1; //1 +
            for (int i = 0; i < numbers.Length; i++) //n*
            {
                if (numbers[i] == key) //1+
                    return i; //1
            }
            return NOT_FOUND; //+ 1
        }

        #endregion

        #region Exercise 4

        /** Exercise# 4.A
         * 1- Ops # m* (n+1) = mn + m 
         * 2- O(n^2)  (m*n behavior is quadratic)
         * 3- NA: same note stated in previous exercises
         */

        public static void Array2DOps1(int[,] numbers)
        {
            for (int r = 0; r < numbers.GetLength(0); r++) // m * 
            {
                for (int c = 0; c < numbers.GetLength(1); c++) //n *
                {
                    Console.Write(numbers[r, c]); // 1
                }
                Console.WriteLine(); // 1
            }
        }

        /** Exercise# 4.B
         * 1- Ops # 1 + m *n * 1 + 1 = 2 + m*n
         * 2- O(n^2) 
         * 3- NA: same note stated in previous exercises
         */
        public static double Array2DOps2(int[,] numbers)
        {
            double sum = 0; //1 (int could be used as well)

            for (int r = 0; r < numbers.GetLength(0); r++) // m * 
                for (int c = 0; c < numbers.GetLength(1); c++) //n *
                    sum += numbers[r, c]; // 1

            return sum; //1
        }
        #endregion

        #region Exercise 5

        /**
         * 1- Ops # 2 + n
         * 2- O(n) 
         * 3- Best case: number is 2 or less | Worst case: NA , any large value for number 
         */
        public static bool MysteryFunctionV1(int number)
        {
            if (number <= 1) // 1 +
                return false;

            for (int i = 2; i < number; i++) // n * 
            {
                if (number % i == 0) //(1)
                    return false;
            }
            return true; // +1 
        }

        /**
         * 1- Ops # 2 + (n/2)
         * 2- O(n) //but we will do half of the comparisons 
         * 3- Best case: number is negative or 2 | Worst case: NA , any large value for number 
         */
        public static bool MysteryFunctionV2(int number)
        {
            if (number <= 1) // 1 +
                return false; // 1 +

            for (int i = 2; i <= number / 2; i++) //n/2 *
            {
                if (number % i == 0) // 1 
                    return false; // 1
            }
            return true; //1
        }

        #endregion

        #region Exercise 6

        /** Exercise# 6.A
         * 1- Ops # n + 2
         * 2- O(n) 
         * 3- NA
         */
        public static long PowerV1(int baseNumber, int power)
        {
            long result = 1; //1
            for (int i = 0; i < power; i++) //n * 1 
            {
                result *= baseNumber;
            }
            return result; //1
        }


        /** Exercise# 6.B
         * 1- Ops # 1 or 2
         * 2- O(1) (Math.Pow is proven mathematically to have a constant run time)
         * 3- NA
         */
        public static double PowerV2(int baseNumber, int power)
        {
            return Math.Pow(baseNumber, power); // 1
        }

        //Let us examine the execution time for PowerV1 & PowerV2
        #endregion
    }
}