using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CS2022.Reflection
{
    public class ReflectionRunner
    {
        public void Run()
        {
            var i = 5;
            Type t1 = typeof(Int32);
            Type t2 = 5.GetType();
            Type t3 = i.GetType();

            Assembly assembly = Assembly.LoadFrom(@"C:\Users\Asus\source\repos\CS2022\CS2022\obj\Debug\net6.0\CS2022.dll");
            //посмотрим все типы в сборке 1 способ
            foreach (Type t in assembly.ExportedTypes)
            {
                Console.WriteLine(t.Name);
            }
            //2 способ более предпочтительный
            Type[] types = assembly.GetTypes();
        }
    }
}
