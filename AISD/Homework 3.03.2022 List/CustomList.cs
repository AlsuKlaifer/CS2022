using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.List
{
    public class CustomList<T> 
    {
        private Node<T> head;
        public CustomList() { }
        public CustomList(T a)
        {
            head = new Node<T>(a);
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
    }
}