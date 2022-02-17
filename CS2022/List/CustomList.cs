using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.List
{
    internal class CustomList
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
        public void AddToHead(int a)
        {
            var newNode = new Node(a);
            newNode.NextNode = head;
            head = newNode;
        }

        public void Add(int a, int position)
        {
            if (position==1)
            {
                AddToHead(a);
                return;
            }

            var headCopy = head;
            for (int i =1; i<position - 2; i++)
            {
                if (headCopy == null)
                    throw new Exception("Список недостаточной длины");
                headCopy = headCopy.NextNode;
            }

            var newNode = new Node(a);
            //если добавляем не в конец то к новому элементу записываем хвост
            if (headCopy.NextNode != null)
                newNode.NextNode = headCopy.NextNode;
            headCopy.NextNode = newNode;
        }
        public override string ToString()
        {
            var headCopy = head;
            StringBuilder result = new StringBuilder();
            if (head == null)
            {
                return "Список пуст";
            }
            while (headCopy.NextNode != null)
            {
                result.Append(headCopy.InfField.ToString() + " ");
                headCopy = (Node)headCopy.NextNode;
            }
            return result.ToString();
        }
    }
}
