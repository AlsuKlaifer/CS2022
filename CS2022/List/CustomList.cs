using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.List
{
    public class CustomList<T> : ICustomCollection<T> where T : IComparable<T>
    {
        /// <summary>
        /// Ссылка на первый элемент связанного списка
        /// </summary>
        private Node<T> head;
        public CustomList() { }

        public CustomList(T a)
        {
            head = new Node<T>(a);
        }

        public CustomList(T[] array)
        {
            foreach (var el in array)
            {
                Add(el);
            }
        }

        /// <summary>
        /// Добавление по умолчанию в конец
        /// </summary>
        public void Add(T a)
        {
            var newNode = new Node<T>(a);

            if (head == null)
            {
                head = newNode;
                return;
            }

            //идем до конца списка
            var headCopy = head;
            while (headCopy.NextNode != null)
            {
                headCopy = headCopy.NextNode;
            }
            headCopy.NextNode = newNode;
        }
        /// <summary>
        /// Добавление в начало
        /// </summary>
        public void AddToHead(T a)
        {
            var newNode = new Node<T>(a);
            newNode.NextNode = head;
            head = newNode;
        }

        /// <summary>
        /// Добавление на опредленную позицию
        /// </summary>
        public void Add(T a, int position)
        {
            if (position == 1)
            {
                AddToHead(a);
                return;
            }

            var headCopy = head;
            for (int i = 1; i <= position - 2; i++)
            {
                if (headCopy == null)
                    throw new ArgumentOutOfRangeException("Список недостаточной длины");
                headCopy = headCopy.NextNode;
            }

            var newNode = new Node<T>(a);
            //если добавляем не в конец то к новому элементу записываем хвост
            if (headCopy.NextNode != null)
                newNode.NextNode = headCopy.NextNode;
            headCopy.NextNode = newNode;
        }

        /// <summary>
        /// Удаление головного элемента
        /// </summary>
        public void DeleteHead()
        {
            if (head == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            if (head.NextNode == null)
            {
                Console.WriteLine("Удален единственный элемент в списке. Список пуст");
                return;
            }
            head = head.NextNode;
        }

        /// <summary>
        /// Удаление последнего элементв
        /// </summary>
        public void DeleteLast()
        {
            if (head == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            if (head.NextNode == null)
            {
                Console.WriteLine("Удален единственный элемент в списке. Список пуст");
                return;
            }
            var nodeCopy = head;
            while (nodeCopy.NextNode.NextNode != null)
            {
                nodeCopy = nodeCopy.NextNode;
            }
            nodeCopy.NextNode = null;
        }

        /// <summary>
        /// Удаление элемента на определенной позиции
        /// </summary>
        public void Delete(int position)
        {
            if (position <= 0)
                throw new Exception("Позиция предусматривает положительное число. Введите корректное значение");
            if (position > Length())
                throw new Exception("Элемента на данной позиции не существует. Введите корректное значение");
            if (position == Length())
            {
                DeleteLast();
                return;
            }
            if (position == 1)
            {
                DeleteHead();
                return;
            }
            var nodeCopy = head;
            for (int i = 1; i <= position - 2; i++)
            {
                nodeCopy = nodeCopy.NextNode;
            }
            nodeCopy.NextNode = nodeCopy.NextNode.NextNode;
        }

        /// <summary>
        /// Удаление предпоследнего элемента
        /// </summary>
        public void DeletePenult()
        {
            var nodeCopy = head;
            while (nodeCopy.NextNode.NextNode.NextNode != null)
            {
                nodeCopy = nodeCopy.NextNode;
            }
            nodeCopy.NextNode = nodeCopy.NextNode.NextNode;
        }

        /// <summary>
        /// Удалить все вхождения какого-то значения
        /// </summary>
        public void DeleteAllValues(T value)
        {
            if (head == null)
                return;
            while (head != null && head.InfField.CompareTo(value) == 0)
                DeleteHead();

            if (head != null)
                DelAllValFromSecondElem(value, head);
        }

        private void DelAllValFromSecondElem(T value, Node<T> headCopy)
        {
            if (headCopy.NextNode == null)
                return;

            if (headCopy.NextNode.InfField.CompareTo(value) == 0)
            {
                DeleteSecondElement(headCopy);
                DelAllValFromSecondElem(value, headCopy);
            }
            else
            {
                DelAllValFromSecondElem(value, headCopy.NextNode);
            }
        }

        /// <summary>
        /// Удаление второго элемента
        /// </summary>
        private void DeleteSecondElement(Node<T> headCopy)
        {
            if (headCopy == null || headCopy.NextNode == null)
                throw new Exception("В методе DeleteSecondElement неверные входные данные");

            headCopy.NextNode = headCopy.NextNode.NextNode;
        }

        /// <summary>
        /// Дз по АСД
        /// Меняем местами каждые два соседних узла
        /// </summary>
        public void ChangeNodes()
        {
            var thirdnode = head.NextNode.NextNode;
            var headcopy = head;
            head = head.NextNode;
            head.NextNode = headcopy;
            while (thirdnode != null && thirdnode.NextNode != null)
            {
                headcopy.NextNode = thirdnode.NextNode;
                headcopy = thirdnode;
                var next = thirdnode.NextNode.NextNode;
                thirdnode.NextNode.NextNode = thirdnode;
                thirdnode = next;
            }
            headcopy.NextNode = thirdnode;
        }

        public int Length()
        {
            int length = 0;
            if(head!= null)
            {
                var headcopy = head;
                while (headcopy != null)
                {
                    length++;
                    headcopy = headcopy.NextNode;
                }
            }
            return length;
        }

        public override string ToString()
        {
            var headCopy = head;
            StringBuilder result = new StringBuilder();
            if (head == null)
            {
                return "Список пуст";
            }
            while (headCopy != null)
            {
                result.Append(headCopy.InfField.ToString() + " ");
                headCopy = (Node<T>)headCopy.NextNode;
            }
            return result.ToString();
        }

        public void WriteToConsole()
        {
            Console.WriteLine(ToString());
        }

        public int Size()
        {
            throw new NotImplementedException();
        }

        public bool isEmpty()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T elem)
        {
            throw new NotImplementedException();
        }

        public void AddRange(T[] elems)
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
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T elem)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T elem)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomListEnumerator<T>(head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}