using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Worker_Event.Example2
{
    /// <summary>
    /// Финансовый отдел
    /// </summary>
    public class FinDepartment
    {
        protected void CalcSalary(Worker w,
            GoVacationParams param)
        {
            Console.WriteLine($"Вычисление отпускных " +
                $"для сотрудника {w.Name}, уходящего в " +
                $"{param.IsAdm} отпуск" +
                $"в период с {param.From.ToShortDateString()}" +
                $" по {param.To.ToShortDateString()}");
        }

        public void Subscribe(Worker w)
        {
            w.GoVacationDelegats += CalcSalary;
        }

        public void Unsubscribe(Worker w)
        {
            w.GoVacationDelegats -= CalcSalary;
        }
    }
}
