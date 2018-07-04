using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable_One
{
    class Program
    {
        static void Main(string[] args)
        {
            //Asks user for input
            Console.WriteLine("Please enter any positive whole number:");
            string userInputOne = Console.ReadLine();

            //If user input is not a positive whole number, ask to re-enter a positive whole number.
            while (checkInputValidity(userInputOne) == false)
            {
                Console.WriteLine("That was not a valid number. Please enter any positive whole number.");
                userInputOne = Console.ReadLine();
            }
            //Converts user input string into integer.
            int userNumberOne = Int32.Parse(userInputOne);

            //Asks user for second input
            Console.WriteLine("Please enter another positive whole number with the same number of digits as the first number:");
            string userInputTwo = Console.ReadLine();

            //If user input is not a valid number, or is not the same number of digits as the first number, ask again.
            while (checkInputValidity(userInputTwo) == false || (userInputOne.Length != userInputTwo.Length))
            {
                Console.WriteLine("What you typed is not a valid number or does not contain the same number of digits as the first number.");
                userInputTwo = Console.ReadLine();
            }
            //Converts second user input into integer.
            int userNumberTwo = Int32.Parse(userInputTwo);

            //Separates the two integers with an array, each element containing one digit.
            int[] userNumberOneArray = separateToDigits(userNumberOne);
            int[] userNumberTwoArray = separateToDigits(userNumberTwo);

            //Verifies if each corresponding digit sum is equal to each other, and prints true or false.
            Console.WriteLine("Does each digit added to each other add to the same number?");
            bool areNumbersEqual = digitComputation(userNumberOneArray, userNumberTwoArray);
            Console.WriteLine(areNumbersEqual);

            Console.ReadKey();
        }

        /// <summary>
        /// This method converts an integer into an array of integers.
        /// </summary>
        /// <param name="number">A number to convert.</param>
        /// <returns>The given number as an array of that number.</returns>
        public static int[] separateToDigits(int number)
        {
            List<int> separateIntegers = new List<int>();
            while (number > 0)
            {
                separateIntegers.Add(number % 10);
                number = number / 10;
            }
            return separateIntegers.ToArray();
        }

        /// <summary>
        /// This method adds each corresponding digit of each array and checks if the sums are equal.
        /// </summary>
        /// <param name="array1">Number input by user converted to array</param>
        /// <param name="array2">Number input by user converted to array</param>
        /// <returns>True if all sums of corresponding digits are equal, otherwise false</returns>
        public static bool digitComputation(int[] array1, int[] array2)
        {
            int onesDigit = array1[0] + array2[0];

            for (int i = 1; i < array1.Length; i++)
            {
                if (array1[i] + array2[i] != onesDigit)
                {
                    return false;
                }
            }

            return true;

        }

        /// <summary>
        /// Checks if user input is a valid number.
        /// </summary>
        /// <param name="userInput">Any user input</param>
        /// <returns>If input contains any letters, or is 0, returns false, otherwise true</returns>
        public static bool checkInputValidity(string userInput)
        {

            if (int.TryParse(userInput, out int isNumber) == false)
            {
                return false;
            }
            else if (isNumber == 0)
            {
                return false;
            }


            return true;
        }
    }
}
