using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Worker_Event.Example2
{
    public class Manager
    {
        private string name;
        public string Name { get { return name; } }
        public Manager(string _name)
        {
            name = _name;
        }
        protected void FindReplacement(Worker w, GoVacationParams param)
        {
            Console.WriteLine($"Происходит поиск замены для сотрудника {w.Name}, " +
                $"уходящего в {param.IsAdm} отпуск в период с {param.From} по {param.To}");
        }
        /// <summary>
        /// подписка на событие выход в отпуск работника
        /// </summary>
        public void Subscribe(Worker w)
        {
            w.GoVacationDelegats += FindReplacement;
        }
        /// <summary>
        /// отписка на событие 
        /// </summary>
        /// <param name="w"></param>
        public void Unscribe(Worker w)
        {
            w.GoVacationDelegats -= FindReplacement;
        }
    }
}
