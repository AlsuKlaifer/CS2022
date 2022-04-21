using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Worker
{
    public class Manager
    {
        public string Name;
        public Manager(string name)
        {
            Name = name;
        }
        public void SetReplace(Worker w, DateTime from, DateTime to)
        {
            Console.WriteLine($"Находим замену работнику {w.Name}");
        }
    }
}
