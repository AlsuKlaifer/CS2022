using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Worker_Event.Event_Example
{
    public class MailManagerRunner
    {
        public void Run()
        {
            var mm = new MailManager();
            mm.SimulateMail("Рената", "Михаил",
                "Констрольная на Codeforces");

            var pager = new Pager();
            pager.Subscribe(mm);
            mm.SimulateMail("Рената", "Тагир",
                "Домашка");

            var fax = new Fax();
            fax.Subscribe(mm);
            pager.UnSubscribe(mm);
            mm.SimulateMail("Рената", "Егор",
                "Список группы");
        }
    }
}
