using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Text;

namespace Lab0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //if arg == 0
            //keep the default values:

            //Defined Variables
            //File vars
            string inputFile = "./input.txt", outputFile = "./output.csv";
            //Support vars
            int size = 20;

            try
            {
                //What are valid  args number and values
                //Only 3: [0] int [1] & [2] string
                if (args.Length == 3)
                {
                    //validate
                    size = int.Parse(args[0]); //throw an exception
                    inputFile = args[1];
                    outputFile = args[2];
                }
                else if (args.Length != 0) // all invalid
                {
                    throw new Exception("Number of arguments is not 3. Please provide only 3");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Arguments error: " + ex.ToString()); //provide example
                return; //stop execution when arguments are not valid.
            }


            try
            {
                //Data array to save read data: filled by the method.
                int[] data = ReadDataFromFile(inputFile, size);
                //Get the largest value
                int largestValue = FindLargestValue(data);
                //Generate Output
                string output = GenerateOutput(data, largestValue);
                //save the data
                SaveData(outputFile, output);

                //Improvements
                Console.WriteLine($"File saved to {outputFile}");
                Console.WriteLine(output);

                Process.Start("notepad.exe",outputFile);


            }
            catch (Exception e)
            {
                //Never throw an exception in main
                Console.WriteLine($"Error occurred: {e.Message}");
            }
        }

        /// <summary>
        /// Method to read a specific number of values from a file.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <exception cref="IOException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public static int[] ReadDataFromFile(string inputFile, int size )
        {
            if(File.Exists(inputFile))
            {
                int[] data = new int[size];
                string line;
                int counter = 0;
                //Reading Data from file
                try
                {
                    using (StreamReader inputReader = new StreamReader(inputFile))
                    {
                        while ((line = inputReader.ReadLine()) != null && counter < size) //Combined condition: end of file & specific size
                        {
                            data[counter++] = int.Parse(line);
                        }
                    }

                        

                    //Validate that file has enough data (s represents the size, c the count of read data)
                    if (counter < size)
                    {
                        throw new Exception("Input file does not have enough data");
                    }

                }
                catch (Exception ex)
                {
                    throw new IOException($"Reading from file error (ReadDataFromFile): {ex.Message}");
                }

                return data;
            }
            else
            {
                throw new FileNotFoundException($"The provide file {inputFile} does not exist");
            }
            
        }

        public static int FindLargestValue(int[] data)
        {
            //Find the largest value
            int largestValue = data[0];
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > largestValue)
                    largestValue = data[i];
            }
            return largestValue;
        }

        public static string GenerateOutput(int[] data, int largestValue)
        {
            //Generate output
            StringBuilder output = new StringBuilder();
            foreach (int number in data)
            {
                output.Append($"{number},");
            }
            output.AppendLine($" Largest Number = {largestValue}");

            return output.ToString();
        }

        public static void SaveData(string filename, string output)
        {
            try
            {
                //Save data to a file.
                File.AppendAllText(filename, output.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error writing to a file (SaveData) {ex.Message}");
            }
        }
    }
}