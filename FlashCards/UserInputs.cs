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
    }
}
