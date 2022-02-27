using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.List
{
    public class CustomList
    {
        /// <summary>
        /// Ссылка на первый элемент связанного списка
        /// </summary>
        private Node head;
        public CustomList() { }

        public CustomList(int a)
        {
            head = new Node(a);
        }
        
        public CustomList(int[] array)
        {
            foreach(int el in array)
                Add(el);
        }

        /// <summary>
        /// Добавление по умолчанию в конец
        /// </summary>
        public void Add(int a)
        {
            var newNode = new Node(a);
            if(head == null)
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
        public void AddToHead(int a)
        {
            var newNode = new Node(a);
            newNode.NextNode = head;
            head = newNode;
        }

        /// <summary>
        /// Добавление на опредленную позицию
        /// </summary>
        public void Add(int a, int position)
        {
            if (position==1)
            {
                AddToHead(a);
                return;
            }

            var headCopy = head;
            for (int i =1; i<=position - 2; i++)
            {
                if (headCopy == null)
                    throw new ArgumentOutOfRangeException("Список недостаточной длины");
                headCopy = headCopy.NextNode;
            }

            var newNode = new Node(a);
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
            if (head.NextNode == null)
            {
                Console.WriteLine("Список пуст");
                return;
            } 
            head = head.NextNode;
        }

        /// <summary>
        /// Удаление последнего элементв
        /// </summary>
        public void DeleteLast()
        {
            if (head.NextNode == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            var nodeCopy = head;
            while(nodeCopy.NextNode.NextNode != null)
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
        /// Удаление числа
        /// </summary>
        public void DeleteNumber(int k)
        {
            var nodeCopy = head;
            int i = 2;
            while (nodeCopy.NextNode.InfField != k)
            {
                nodeCopy = nodeCopy.NextNode;
                i++;
            }
            Delete(i);
        }

        /// <summary>
        /// Возвращает сумму элементов списка
        /// </summary>
        public int Sum()
        {
            var headcopy = head;
            int sum = 0;
            while (headcopy != null)
            {
                sum += headcopy.InfField;
                headcopy = headcopy.NextNode;
            }
            return sum;
        }

        /// <summary>
        /// Вставляет число m до и после первого элемента, равного k
        /// </summary>
        public void PasteNumber(int k, int m)
        {
            var nodeCopy = head;
            int i = 2;
            while (nodeCopy.NextNode.InfField != k)
            {
                nodeCopy = nodeCopy.NextNode;
                i++;
            }
            Add(m, i);
            Add(m, i+2);
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
                headCopy = (Node)headCopy.NextNode;
            }
            return result.ToString();
        }

        public void WriteToConsole()
        {
            Console.WriteLine(ToString());
        }
    }
}