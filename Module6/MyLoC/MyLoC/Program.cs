using System;
using System.Reflection;

namespace MyLoC
{
    class Program
    {
        static void Main(string[] args)
        {
            Reflection();
        }

        public static void Reflection()
        {
            Type[] typeList = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in typeList)
            {
                Console.WriteLine($"\nReturn information about class: {type.Name}");
                Console.WriteLine("Return information about all methods in current build:");
                MethodInfo[] methodInfoMeta = type.GetMethods(BindingFlags.Instance
                    | BindingFlags.Static
                    | BindingFlags.Public);

                foreach (var typeData in methodInfoMeta)
                {
                    Console.WriteLine(typeData.Name);
                }
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}