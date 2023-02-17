using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards
{
    public class UserInputs
    {
        public string GetStringInputs(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            while (input == null || input == "")
            {
                Console.Write("Invalid Input. Try Again: ");
                input = Console.ReadLine();
            }
            return input;
        }
        public int GetIntInputs(string prompt)
        {
            Console.Write(prompt);
            string numberInput = Console.ReadLine();

            while (!int.TryParse(numberInput, out _) || Convert.ToInt32(numberInput) < 0)
            {
                Console.Write("\n\nInvalid number. Try again: ");
                numberInput = Console.ReadLine();

            }
            int finalInput = Convert.ToInt32(numberInput);
            return finalInput;


        }
    }
}
