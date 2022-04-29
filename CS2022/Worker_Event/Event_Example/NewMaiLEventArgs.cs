using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Worker_Event.Event_Example
{
    public class NewMailEventArgs : EventArgs
    {
        private string mFrom, mTo, subject;
        public NewMailEventArgs(string mf, string mt, string sbj)
        {
            mFrom = mf;
            mTo = mt;
            subject = sbj;
        }
        public string MailFrom { get { return mFrom; } }
        public string MailTo { get { return mTo; } }
        public string Subject { get { return subject; } }
    }
}
