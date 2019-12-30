using ConsoleAppExample.SettingClasses;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace ConsoleAppExample.IocContainer
{
    public class Container
    {
        private Type nameClass;

        public Container(string path)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    var json = JsonConvert.DeserializeObject<ConfigLoader>(streamReader.ReadToEnd());
                    nameClass = Type.GetType(Assembly.GetEntryAssembly().GetName().Name + ".SettingClasses." + json.Class);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public I CreateInstance<I>()
             where I : class
        {
            return (I)Activator.CreateInstance(nameClass);           
        }
    }
}

      