using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD.SemesterWork2
{
    public class HashedArrayTree<T>
    {
        /// <summary>
        /// Массивы с данными, хранящиеся в Hashed Array Tree
        /// </summary>
        private T[][] arrays;

        /// <summary>
        /// Логарифм по основанию 2 от размера массива указателей (top), используется для побитовых вычислений индексов
        /// </summary>
        private int power;

        /// <summary>
        /// Количество элементов в Hashed Array Tree
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Текущая вместимость массивов с данными, хранящихся в Hashed Array Tree
        /// </summary>
        public int Capacity { get; set; }

        public HashedArrayTree()
        {
            arrays = new T[2][];
            power = 1;
            Count = 0;
            Capacity = 4;
        }

        /// <summary>
        /// Возвращает индекс нужного массива-листа (leaf) в массиве указателей (top), по которому можно найти элемент с заданным индексом
        /// </summary>
        private int topIndex(int index)
        {
            // Данный индекс вычисляется делением индекса искомого элемента на размер массива указателей (top).
            // Так как размер массива указателей (top) всегда равен степени числа 2, деление можно выполнить битовым сдвигом на power, 
            // где 2^power - размер массива указателей (top), то есть power раз выполняется деление на 2
            return index >> power;
        }

        /// <summary>
        /// Возвращает индекс искомого элемента в массиве-листе
        /// </summary>
        private int leafIndex(int index)
        {
            // Данный индекс вычисляется как остаток от деления индекса искомого элемента на размер массива указателей (top).
            // Так как размер массива указателей (top) всегда равен степени числа 2, остаток можно вычислить с помощью побитовых операций.
            // Пример. Пусть index = 19, topSize = 8, искомый индекс: leafIndex = 19 % 8 = 3
            // index = 10011, topSize = 01000, topSize - 1 = 00111, index & (topSize - 1) = 10011 & 00111 = 00011 = 3
            return index & (arrays.Length - 1);
        }

        /// <summary>
        /// Элемент с заданным индексом в Hashed Array Tree
        /// </summary>
        public T this[int index]
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
        /// <param name="newSize">Размер нового массива указателей(top) и новых массивов-листов (leaf)</param>
        /// <param name="newPower">Логарифм по основанию 2 от размера нового массива указателей (top)</param>
        private void copyToNewArray(int newSize, int newPower)
        {
            T[][] newArrays = new T[newSize][];
            int oldArraysIndex = 0;
            for (int i = 0; i < newSize; i++)
            {
                if (oldArraysIndex == Count) break;
                newArrays[i] = new T[newSize];
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
        /// <param name="increase">Если true, увеличить размер; если false, уменьшить размер</param>
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
            copyToNewArray(newSize, newPower); // Копируем элементы старых массивов в новые
        }

        /// <summary>
        /// Добавляет элемент в конец Hashed Array Tree
        /// </summary>
        public void Add(T value)
        {
            if (Count == Capacity) resize(true);
            var topIdx = topIndex(Count);
            var leafIdx = leafIndex(Count);
            if (arrays[topIdx] == null) arrays[topIdx] = new T[arrays.Length];
            arrays[topIdx][leafIdx] = value;
            Count++;
        }

        /// <summary>
        /// Вставляет элемент в Hashed Array Tree по указанному индексу, остальные элементы сдвигаются
        /// </summary>
        public void Insert(int index, T value)
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
        public int IndexOf(T value)
        {
            for (int i = 0; i < Count; i++)
                if (object.Equals(this[i], value)) return i;
            return -1;
        }

        /// <summary>
        /// Определяет, находится ли элемент в Hashed Array Tree
        /// </summary>
        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        /// <summary>
        /// Удаляет элемент из Hashed Array Tree по указанному индексу, остальные элементы сдвигаются
        /// </summary>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            T previousValue = default(T);
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
        public void Remove(T value)
        {
            int index = IndexOf(value);
            if (index != -1) RemoveAt(index);
            else Console.WriteLine("Элемент не существует");
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
