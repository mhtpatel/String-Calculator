using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
   public class Program
    {
        private static bool keepRunning = true; //ctrl+c
        public static void Main(string[] args)
        {

            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e)
            {
                Console.WriteLine("Ctrl+C pressed");
                e.Cancel = true;
                Program.keepRunning = false;
            };

            while (keepRunning)
            {
                string number = null;
                NewProgram np = new NewProgram();
                Console.Write("\n\nString Calculator :\n");
                Console.WriteLine("Enter a string value: ");

                number = Console.ReadLine();
                Console.WriteLine("\nFinal result is : {0} \n", np.AddOperation(number));
                Console.ReadKey();
            }
            
        }
        

    }

    public class NewProgram
    { 
        //variables declaration

        private int maxValue = 1000;
        public string custom_Seperator = "//";
        private List<string> Separators = new List<string>() { ",", "\n", "\\", ";", "n", "]" };
        public int AddOperation(string numberList)
        {
            //-->check if string is null or blank
            if (String.IsNullOrWhiteSpace(numberList))
                return 0;
            //<--
            //-->to use custom separator logic
            if (numberList.StartsWith(custom_Seperator))
            {
                numberList = CustomSeparators(numberList);
            }
            //<--
            //--> for filtered number
            var filterNumbers = FilterNumbers(numberList);
            //<--
            return filterNumbers.Sum();
        }
        public string CustomSeparators(string numberList)
        {
            string[] separatorList = { custom_Seperator, "[", "]" };
            var customSeparator = numberList.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).First();
            numberList = numberList.Substring(separatorList.Length, numberList.Length - separatorList.Length);
            var bulkSeparator = customSeparator.Split(separatorList, StringSplitOptions.RemoveEmptyEntries);
            foreach (var ind in bulkSeparator)
            {
                Separators.Add(ind);
            }
            return numberList;
        }
        public IList<int> FilterNumbers(string numberList)
        {
            var numList = numberList.Split(Separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            var filtered = new List<int>();
            foreach (var num in numList)
            {

                int filteredNumber = 0;
                long number1 = 0;
                //-->if value is not number put 0
                bool canConvert = long.TryParse(num, out number1);
                if (canConvert == true)
                {
                    filteredNumber = int.Parse(num);
                }
                else
                {
                    filteredNumber = 0;
                }
                //<--
                //-->check for negative value
                if (filteredNumber < 0)
                {
                    throw new ApplicationException("Number should be positive only.");
                }
                //check for max value(here is 1000)
                if (filteredNumber <= maxValue)
                {
                    filtered.Add(filteredNumber);
                }
            }
            return filtered;
        }
    }
    
}
