using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Worker_Event.Event_Example
{
    /// <summary>
    /// Факс - подписчик
    /// </summary>
    internal sealed class Fax
    {
        /// <summary>
        /// Подписаться на событие новое сообщение MailManager-а
        /// </summary>
        public void Subscribe(MailManager mm)
        {
            mm.NewMail += PrintMail;
        }

        /// <summary>
        /// Отписаться от события новое сообщение MailManager-а
        /// </summary>
        public void UnSubscribe(MailManager mm)
        {
            mm.NewMail -= PrintMail;
        }
        /// <summary>
        /// Обработчик - распечатать письмо
        /// </summary>
        /// <param name="sender">источник события - MailManager</param>
        /// <param name="e">параметры события новое письмо</param>
        private void PrintMail(object sender, NewMailEventArgs e)
        {
            Console.WriteLine($"Печатаю письмо от {e.MailFrom}" +
                $" для {e.MailTo} с темой {e.Subject}");
        }
    }
}