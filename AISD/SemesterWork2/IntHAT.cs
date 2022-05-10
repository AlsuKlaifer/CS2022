using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AISD.SemesterWork2
{
    /// <summary>
    /// Hashed Array Tree <int> для вычисления времени работы
    /// </summary>
    public class IntHAT
    {
        /// <summary>
        /// Заполняет НАТ числами от from до to
        /// </summary>
        public void FillHAT(int from, int to)
        {
            for (int i = from; i <= to; i++)
                this.Add(i);
        }
        public void StopWatch(int num)
        {
            var sw = new Stopwatch();
            sw.Start();
            //this.Add(num);
            //this.Contains(num);
            this.Remove(num);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
        public void Run()
        {
            var hat = new IntHAT();
            hat.FillHAT(1, 4);
            hat.StopWatch(3);

            hat.FillHAT(5, 16);
            hat.StopWatch(10);
            hat.WriteToConsole();

            hat.FillHAT(17, 64);
            hat.StopWatch(32);

            hat.FillHAT(65, 256);
            hat.StopWatch(128);

            hat.FillHAT(257, 1024);
            hat.StopWatch(512);

            hat.FillHAT(1025, 4096);
            hat.StopWatch(2048);

            hat.FillHAT(4097, 16384);
            hat.StopWatch(8200);

            hat.FillHAT(16385, 65536);
            hat.StopWatch(30000);

            hat.FillHAT(65537, 262144);
            hat.StopWatch(131010);

            hat.FillHAT(262145, 1048576);
            hat.StopWatch(512000);

            hat.FillHAT(1048577, 4194304);
            hat.StopWatch(2100100);

            hat.FillHAT(4194305, 16777216);
            hat.StopWatch(8200200);
        }
        /// <summary>
        /// Массивы с данными, хранящиеся в Hashed Array Tree
        /// </summary>
        private int[][] arrays;

        /// <summary>
        /// Логарифм по основанию 2 от размера массива указателей (top), используется для побитовых вычислений индексов
        /// </summary>
        private int power;

        /// <summary>
        /// Количество элементов в Hashed Array Tree
        /// </summary>
        public int Count { get; internal set; }

        /// <summary>
        /// Текущая вместимость массивов с данными, хранящихся в Hashed Array Tree
        /// </summary>
        public int Capacity { get; internal set; }

        /// <summary>
        /// Конструктор, создающий пустой Hashed Array Tree
        /// </summary>
        public IntHAT()
        {
            arrays = new int[2][];
            power = 1;
            Count = 0;
            Capacity = 4;
        }

        /// <summary>
        /// Возвращает индекс нужного массива-листа (leaf) в массиве указателей (top), по которому можно найти элемент с заданным индексом
        /// </summary>
        private int topIndex(int index)
        {
            return index >> power;
        }

        /// <summary>
        /// Возвращает индекс искомого элемента в массиве-листе
        /// </summary>
        private int leafIndex(int index)
        {
            return index & (arrays.Length - 1);
        }

        /// <summary>
        /// Элемент с заданным индексом в Hashed Array Tree
        /// </summary>
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                return arrays[topIndex(index)][leafIndex(index)];
            }
            set
            {
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                arrays[topIndex(index)][leafIndex(index)] = value;
            }
        }

        /// <summary>
        /// Создаёт новые массивы с заданным размером и копирует в них данные из старых массивов
        /// </summary>
        private void copyToNewArrays(int newSize, int newPower)
        {
            int[][] newArrays = new int[newSize][];
            int oldArraysIndex = 0;
            for (int i = 0; i < newSize; i++)
            {
                if (oldArraysIndex == Count) break;
                newArrays[i] = new int[newSize];
                for (int j = 0; j < newSize; j++)
                {
                    newArrays[i][j] = this[oldArraysIndex];
                    oldArraysIndex++;
                    if (oldArraysIndex == Count) break;
                }
            }
            arrays = newArrays;
            power = newPower;
            Capacity = newSize << newPower;
        }

        /// <summary>
        /// Измененяет размеры массивов с данными, хранящихся в Hashed Array Tree
        /// </summary>
        private void resize(bool increase, int minCapacity = 0)
        {
            int newSize = arrays.Length;
            int newPower = power;
            if (increase)
            {
                newSize = newSize << 1; // умножение на 2
                newPower++;
            }
            else
            {
                newSize = newSize >> 1; // деление на 2
                newPower--;
            }
            copyToNewArrays(newSize, newPower); // Копируем элементы старых массивов в новые
        }

        /// <summary>
        /// Добавляет элемент в конец Hashed Array Tree
        /// </summary>
        public void Add(int value)
        {
            if (Count == Capacity) resize(true);
            var topIdx = topIndex(Count);
            var leafIdx = leafIndex(Count);
            if (arrays[topIdx] == null) arrays[topIdx] = new int[arrays.Length];
            arrays[topIdx][leafIdx] = value;
            Count++;
        }
        /// <summary>
        /// Вставляет элемент в Hashed Array Tree по указанному индексу, остальные элементы сдвигаются
        /// </summary>
        public void Insert(int index, int value)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            Add(value);
            if (index == Count) return;
            var previousValue = value;
            for (int i = index; i < Count; i++)
            {
                var temp = this[i];
                this[i] = previousValue;
                previousValue = temp;
            }
        }

        /// <summary>
        /// Ищет элемент в Hashed Array Tree и возвращает индекс его первого вхождения
        /// </summary>
        public int IndexOf(int value)
        {
            for (int i = 0; i < Count; i++)
                if (object.Equals(this[i], value)) return i;
            return -1;
        }

        /// <summary>
        /// Определяет, находится ли элемент в Hashed Array Tree
        /// </summary>
        public bool Contains(int value)
        {
            return IndexOf(value) != -1;
        }

        /// <summary>
        /// Удаляет элемент из Hashed Array Tree по указанному индексу, остальные элементы сдвигаются
        /// </summary>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            int previousValue = default(int);
            for (int i = Count - 1; i >= index; i--)
            {
                var temp = this[i];
                this[i] = previousValue;
                previousValue = temp;
            }
            Count--;
            // Уменьшаем размеры массивов, если количество элементов в Hashed Array Tree составляет 1/8 от вместимости
            if (Count << 3 == Capacity) // Умножаем Count на 8
                resize(false);
            // Удаляем последний выделенный массив-лист (leaf), если количество элементов кратно размеру массива указателей (top)
            if (Count % arrays.Length == 0) arrays[topIndex(Count)] = null;
        }

        /// <summary>
        /// Удаляет элемент (первое вхождение) из Hashed Array Tree.
        /// </summary>
        public void Remove(int value)
        {
            int index = IndexOf(value);
            if (index != -1) RemoveAt(index);
            else Console.WriteLine("Элемента не существует");
        }

        /// <summary>
        /// Вывод на консоль
        /// </summary>
        public void WriteToConsole()
        {
            var count = Count;
            var length = Convert.ToInt32(Math.Pow(2, power));
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (count == 0) return;
                    Console.Write(this[i * length + j] + " ");
                    count--;
                }
                Console.WriteLine();
            }
        }
    }
}
