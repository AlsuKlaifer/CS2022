using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Worker_Event.Event_Example
{
    public sealed class Pager
    {
        /// <summary>
        /// Подписаться на событие новое сообщение MailManager-а
        /// </summary>
        public void Subscribe(MailManager mm)
        {
            mm.NewMail += Show;
        }

        /// <summary>
        /// Отписаться от события новое сообщение MailManager-а
        /// </summary>
        public void UnSubscribe(MailManager mm)
        {
            mm.NewMail -= Show;
        }
        private void Show(object sender, NewMailEventArgs e)
        {
            Console.WriteLine($"Печать сообщения от {e.MailFrom}" +
                $" для {e.MailTo} с темой {e.Subject}");
        }
    }
}
