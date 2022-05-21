using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.List
{
    public class CustomArrayCollection<T> : ICustomCollection<T> where T : IEquatable<T>
    {
        private T[] array;

        public CustomArrayCollection()
        {
            array = new T[0];
        }
        
        public CustomArrayCollection(T el)
        {
            array = new T[1] { el };
        }

        public CustomArrayCollection(T[] array)
        {
            this.array = array;
        }

        public void Add(T elem)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = elem;
        }

        public void AddRange(T[] elems)
        {
            if (elems == null && elems.Length == 0)
                return;
            if (array == null && array.Length == 0)
            {
                foreach (T elem in elems)
                    Add(elem);
                return;
            }
            Array.Resize(ref array, array.Length + elems.Length);
            for (int i = elems.Length; i > 0; i--)
                array[array.Length - i] = elems[elems.Length - i];
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T elem)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)array.GetEnumerator();
        }

        public int IndexOf(T elem)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T elem)
        {
            throw new NotImplementedException();
        }

        public bool isEmpty()
        {
            throw new NotImplementedException();
        }

        public void Remove(T elem)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll(T elem)
        {
            while (array.Contains(elem))
            {
                for (int i = 0; i < array.Length; i++)
                    if (array[i].Equals(elem))
                        RemoveAt(i);
                RemoveAll(elem);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0)
                throw new Exception("Индекс должен быть больше нуля");
            if (array == null || (array.Length - 1) < index)
                throw new Exception("Индекс выходит за пределы списка");

            //Перезаписываю все элементы, начиная с позиции index + 1,
            // на одну ячейку влево
            for (int i = index; i < array.Length - 1; i++)
                array[i] = array[i + 1];
            //уменьшая размер массива
            Array.Resize(ref array, array.Length - 1);
        }

        public void Reverse()
        {
            var arr = new T[array.Length];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = array[arr.Length-i-1];
            array = arr;
        }

        public int Size()
        {
            return array.Length;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }
        public override string ToString()
        {
            if (array[0] == null)
                return "Список пуст";
            var sb = new StringBuilder();
            for(int i = 0; i < array.Length-1;i++)
            {
                sb.Append(array[i].ToString());
                if (array[i+1] != null)
                    sb.Append("<=>");
            }
            sb.Append(array[array.Length - 1].ToString());
            return sb.ToString();
        }

        public void WriteToConsole()
        {
            Console.WriteLine(ToString());
        }
    }
}
