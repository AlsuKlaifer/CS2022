using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.List
{
    /// <summary>
    /// Класс для вызова и проверки функциональности класса CustomList
    /// </summary>
    public class CustomListRunner
    {
        public void Run()
        {
            try
            {
                var list = new CustomList<int>();
                list.WriteToConsole();

                var list1 = new CustomList<int>(5);
                list1.WriteToConsole();

                list.Add(1);
                list.WriteToConsole();
                list.Add(2);
                list.WriteToConsole();
                list.Add(3);
                list.WriteToConsole();
                list.AddToHead(0);
                list.WriteToConsole();
                list.Add(5, 1);
                list.WriteToConsole();
                list.Add(11, 3);
                list.WriteToConsole();
                list.Add(10, 2);
                list.WriteToConsole();
                list.DeletePenult();
                list.WriteToConsole();
                list.DeleteNumber(0);
                list.WriteToConsole();
                list.Add(11);
                list.WriteToConsole();
                Console.WriteLine(list.Sum());
                list.PasteNumber(11, 9);
                list.WriteToConsole();
                list.ChangeNodes();
                list.WriteToConsole();
                list.Add(5);
                list.ChangeNodes();
                list.WriteToConsole();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Добавление на позицию: "
                    + ex.Message + " " + ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при выполнении методов " +
                    "линейного списка на основе связного "
                    + ex.Message + " " + ex.StackTrace);
            }
            finally
            {
                //Тут блок finally не нужен, просто тренируемся писать
                Console.WriteLine("Финальные действия выполняются всегда");
            }
        }
    }
}
