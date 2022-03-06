using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.LinkedList
{
    public class CustomArrayCollection<T> : ICustomCollection<T>
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
            throw new NotImplementedException();
        }

        public void AddRange(T[] elems)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T elem)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }
    }
}
