using ConsoleAppExample.SettingClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ConsoleAppExample.IocContainer
{
    public class Container
    {
        private Type _nameClass;
        private Type _nameInterface;
        private Dictionary<Type, Type> _dependencies = new Dictionary<Type, Type>();

        public Container(string path)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    var json = JsonConvert.DeserializeObject<ConfigLoader>(streamReader.ReadToEnd());
                    _nameClass = Type.GetType(Assembly.GetEntryAssembly().GetName().Name + ".SettingClasses." + json.Class);
                    _nameInterface = Type.GetType(Assembly.GetEntryAssembly().GetName().Name + "." + json.Interface);
                    RegistreDependency(_nameInterface, _nameClass);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void RegistreDependency(Type key, Type value)
        {
            _dependencies.Add(key, value);
        }

        public I CreateInstance<I>()
            where I : class
        {
            Type key = typeof(I);
            if (_dependencies.ContainsKey(key))
            {
                return (I)Activator.CreateInstance(_dependencies[key]);
            }

            throw new InvalidOperationException("Зависимость не найдена.");
        }
    }
}

      