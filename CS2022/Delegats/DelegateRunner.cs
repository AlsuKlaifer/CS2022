using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Delegats
{
    public class DelegateRunner
    {
        //создаем тип делегата, который не принимает вх параметров и не возвраәает результат
        public delegate void Message();
        public void Run()
        {
            //экземпляр делегата
            Message msgHello = WriteHello;
            //способы вызова
            // 1) 
            msgHello();
            // 2) cherez Invoke
            msgHello.Invoke();

            Message msg
        }
        //функция, которая по вх параметрам и исх значению соответствует типу делегата Message
        public void WriteHello()
        { Console.WriteLine("Hello"); }
    }
}
