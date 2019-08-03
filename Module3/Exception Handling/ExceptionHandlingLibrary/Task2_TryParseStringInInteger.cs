using System;

namespace ExceptionHandlingLibrary
{
    /* Библиотека классов, которая содержит метод преобразования строки в целое число.
     * С обработкой ошибок.
     */
    public static class Task2_TryParseStringInInteger
    {
        public static void TryParsStringInInteger(string value)
        {
            try
            {
                int.Parse(value);
                Console.WriteLine($"After conversion: {value}");              
            }
            catch (FormatException ex)
            {
               Console.WriteLine($"Cann't conversion!\n{ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception:\n{ex}");
            }
        }
    }
}
