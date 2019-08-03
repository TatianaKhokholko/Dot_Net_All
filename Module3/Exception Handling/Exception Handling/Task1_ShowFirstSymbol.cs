using System;
using ExceptionHandlingLibrary;

namespace Exception_Handling
{
    /*
     * Консольное приложение, которое выводит на экран первый из введенных символов строки ввода.
     **/
    class Task1_ShowFirstSymbol
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the text\n");
            try
            {
                var enterText = Console.ReadLine();
                var showResult = enterText.Remove(1);
                Console.WriteLine($"After filter: {showResult}");
                Task2_TryParseStringInInteger.TryParsStringInInteger(showResult);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"You entered is nixuya!\n'{ex}'");
            }
            finally
            {
                Console.WriteLine("Block finally.");
            }
            Console.ReadKey();
        }
    }
}
