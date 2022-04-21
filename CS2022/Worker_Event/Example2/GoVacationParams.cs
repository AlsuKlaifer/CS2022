using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Worker_Event.Example2
{
    public class GoVacationParams
    {
        private DateTime from;
        private DateTime to;
        private bool isAdm;
        public DateTime From { get { return from; } }
        public DateTime To { get { return from; } }
        public string IsAdm { get { return isAdm? "административный" : "оплачиваемый"; } }

        public GoVacationParams(DateTime from, DateTime to, bool isAdm)
        {
            this.from = from;
            this.to = to;
            this.isAdm = isAdm;
        }
    }
}
