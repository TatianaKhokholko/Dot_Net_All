using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ConsoleAppExample.IocContainer
{
    public class Container
    {
        private Dictionary<Type, Type> _dependencies = new Dictionary<Type, Type>();
   
        public Container(Type key, Type value)
        {
            _dependencies.Add(key, value);
        }

        //public void RegistreDependency(Type key, Type value)
        //{
        //    _dependencies.Add(key, value);
        //}

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

      