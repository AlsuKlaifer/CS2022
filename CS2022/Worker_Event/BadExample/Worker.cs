using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Worker
{
    public class Worker
    {
        public string Name;
        public Manager Manager;
        public FinDepartment Fd;
        public Worker(string name)
        {
            Name = name;
        }
        public void GoVacation(DateTime from, DateTime to, bool isAdm)
        {
            if (Manager != null)
                Manager.SetReplace(this, from, to);
            if (Fd != null)
                Fd.CalcSalary(this, from, to, isAdm);
        }
    }
}
