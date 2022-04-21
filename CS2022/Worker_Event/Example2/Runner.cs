using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Worker_Event.Example2
{
    public class Runner
    {
        public void Run()
        {
            var m1 = new Manager("First manager");
            var fd = new FinDepartment();
            var w1 = new Worker("First worker");

            //подписок нет, 
            //вызовем выход в отпуск у работника
            w1.InitVacation(
                new DateTime(2022, 03, 01),
                new DateTime(2022, 03, 14),
                false);

            //подписываю менеджера на сотрудника,
            //чтобы отслеживать выход в отпуск
            m1.Subscribe(w1);
            w1.InitVacation(
                new DateTime(2022, 03, 01),
                new DateTime(2022, 03, 14),
                false);
        }
    }
}
