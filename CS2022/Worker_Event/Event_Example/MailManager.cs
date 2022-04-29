using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Worker_Event.Event_Example
{
    public class MailManager
    {
        /// <summary>
        /// Событие - новое сообщение
        /// </summary>
        public event EventHandler<NewMailEventArgs> NewMail;
        /// <summary>
        /// Обработка события
        /// </summary>
        protected virtual void OnNewMail(NewMailEventArgs args)
        {
            EventHandler<NewMailEventArgs> temp = Volatile.Read(ref NewMail);
            if(temp != null) temp.Invoke(this, args);
        }
        /// <summary>
        /// Симуляция события
        /// </summary>
        public void SimulateMail(string from, string to, string sbj)
        {
            var args = new NewMailEventArgs(from, to, sbj);
            OnNewMail(args);
        }
    }
}
