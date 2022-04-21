using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Worker_Event.Example2
{
    public class Worker
    {
        private string name;
        public string Name { get { return name; } }

        public Action<Worker, GoVacationParams> GoVacationDelegats;

        public Worker(string _name)
        {
            name = _name;
        }
        public void InitVacation(DateTime from, DateTime to, bool isAdm)
        {
            var param = new GoVacationParams(from, to, isAdm);
            var goVacParamCopy = GoVacationDelegats;
            if (goVacParamCopy != null)
                goVacParamCopy(this, param);
                
        }
    }
}
