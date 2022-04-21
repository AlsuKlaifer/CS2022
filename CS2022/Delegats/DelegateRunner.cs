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

        public delegate int SingleCalc(int x);

        public int PlusOne(int y)
        {
            return y + 1;
        }
        public int ModFive(int z)
        {
            return z % 5;
        }

        public void Run()
        {
            //способ создания 1
            SingleCalc d1;
            d1 = PlusOne;
            //2
            var d11 = new SingleCalc(PlusOne);

            //способ вызова 1
            int a = 5;
            a = d1(a);
            //a = d1(5) => a = PlusOne(5);

            //способ вызова 2
            a = d1.Invoke(a);

            //меняем значение
            d1 = ModFive;
            a = d1(a);

            //создание цепочки делегатов
            //1 переменная смотрит на несколько функций
            d1 += PlusOne;
            d1 += PlusOne;
            d1 += PlusOne;
            a = d1(a);

            //удаление из цепочки делегатов (удаляется первое вхождение)
            d1 -= PlusOne;
            a = d1(a);

            //способ создания цепочки
            SingleCalc d2 = PlusOne;
            SingleCalc d22 = ModFive;
            SingleCalc d222 = d2 + d22;
            a = d222(a);

            //анонимные методы
            SingleCalc sc = delegate (int x) { return x - 1; };
            SingleCalc anonPlusOne = delegate (int x) { return x + 1; };

            //лямбда-выражения
            SingleCalc lamPluOne = (int x) => { return x + 1; };
            Message lamHello = () => { Console.WriteLine("Hello"); };
            SingleCalc d4 = (int x) => x + 2;
            SingleCalc d44 = (int x) =>
            {
                x = x * 2;
                x = x - 3;
                return x;
            };
            d44(5);

            //встроенный делегат Function 
            var d5 = new Func<int, int>(PlusOne);
            var d55 = new Func<int, string, string>(
                (int x, string s) =>
                {
                    x = x + 3;
                    s = s + x.ToString();
                    return s;
                });
            var d555 = new Func<string>(() => DateTime.Now.ToShortDateString());

            //встроенный делегат Action
            var d6 = new Action(()
                => Console.WriteLine(DateTime.Now.ToShortDateString()));
            var d66 = new Action<int, int, string>(
                (int x, int y, string s) =>
                {
                    x += y;
                    Console.WriteLine(x + s);
                });


            //экземпляр делегата
            Message msgHello = WriteHello;
            //способы вызова
            // 1) 
            msgHello();
            // 2) cherez Invoke
            msgHello.Invoke();

            Message msg = new Message(WriteHello);
        }
        //функция, которая по вх параметрам и исх значению соответствует типу делегата Message
        public void WriteHello()
        { Console.WriteLine("Hello"); }
    }
}
