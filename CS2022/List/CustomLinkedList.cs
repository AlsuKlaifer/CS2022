using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS2022.List;

namespace CS2022.List
{
    /// <summary>
    /// Линейный список на основе двунаправленного списка
    /// </summary>
    public class CustomLinkedList<T> : ICustomCollection<T> where T : IComparable<T>
    {
        private LinkedNode<T> head;
        public CustomLinkedList() { }
        public CustomLinkedList(T elem)
        {
            head = new LinkedNode<T>(elem);
        }
        public CustomLinkedList(T[] array)
        {
            if (array == null && array.Length == 0)
                return;
            //создание головного элемента 
            head = new LinkedNode<T>(array[0]);

            if (array.Length > 1)
            {
                var headCopy = head;
                for (int i = 1; i < array.Length; i++)
                {
                    //создали новый узел (элемент связного списка)
                    var node = new LinkedNode<T>(array[i]);
                    //задаем новому узлу предыдущий элемент
                    //им будет тот элемент, на который смотрит headCopy
                    node.PrevNode = headCopy;
                    //последнему элементу списка присваиваем 
                    //ссылку на следующий элемент, которым
                    //является добавляемый элемент
                    headCopy.NextNode = node;
                    headCopy = headCopy.NextNode;
                }
            }
        }
        public override string ToString()
        {
            if (head == null)
                return "Список пуст";
            var sb = new StringBuilder();
            var headCopy = head;
            while (headCopy != null)
            {
                sb.Append(headCopy.InfField.ToString());
                if (headCopy.NextNode != null)
                    sb.Append("<=>");
                headCopy = headCopy.NextNode;
            }
            return sb.ToString();
        }

        public void WriteToConsole()
        {
            Console.WriteLine(ToString());
        }

        public void Add(T elem)
        {
            if (head == null)
            {
                head = new LinkedNode<T>(elem);
                return;
            }
            var headcopy = head; 
            while (headcopy.NextNode != null)
                headcopy = headcopy.NextNode;
            var node = new LinkedNode<T>(elem);
            node.PrevNode = headcopy;
            headcopy.NextNode = node;
        }

        public void AddRange(T[] elems)
        {
            if (elems == null && elems.Length == 0)
                return;
            var headcopy = head;
            while (headcopy.NextNode != null)
                headcopy = headcopy.NextNode;
            for (int i = 0; i < elems.Length; i++)
            {
                var node = new LinkedNode<T>(elems[i]);
                node.PrevNode = headcopy;
                headcopy.NextNode = node;
                headcopy = headcopy.NextNode;
            }
        }

        public void Clear()
        {
            head = null;
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
            if(index <= 0)
                throw new Exception("Позиция должна быть больше единицы");

            if (head == null || Size() < index)
                throw new Exception("Нет данной позиции в списке");

            if (index == 1)
                head = head.NextNode;

            var headCopy = head;
            for (int i = 1; i <= index - 1; i++)
            {
                headCopy = headCopy.NextNode;
            }

            //Если последний элемент
            if (headCopy.NextNode == null)
            {
                headCopy.PrevNode.NextNode = null;
            }
            else
            {
                //Делаем, что предшествующий удаляемому элемент
                //смотрит на следующий за удаляемым
                headCopy.PrevNode.NextNode = headCopy.NextNode;
                //Делаем, что следующий за удаляемым элемент
                //смотрит на предшествующий удаляемому
                headCopy.NextNode.PrevNode = headCopy.PrevNode;
            }
        }

        public void Reverse()
        {
            if (head == null || head.NextNode == null)
                return;

            LinkedNode<T> headReverse = null;
            while (head != null)
            {
                #region Добавляем элемент в перевернутый список
                //Создаем новый узел
                var newNode = new LinkedNode<T>(head.InfField);
                //новый элемент ссылается на 1 элемент перевернутого списка
                newNode.NextNode = headReverse;
                headReverse = newNode;
                #endregion

                #region Удаление элемента из изначального списка
                head = head.NextNode;
                #endregion
            }

            head = headReverse;
        }

        public int Size()
        {
            if (head == null)
                return 0;
            var headcopy = head;
            int k = 1;
            while (headcopy.NextNode != null)
            {
                k++;
                headcopy = headcopy.NextNode;
            }
            return k;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
