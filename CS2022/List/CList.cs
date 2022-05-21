using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.List
{
    internal class CList
    {
        /// <summary>
        /// Ссылка на первый элемент связанного списка
        /// </summary>
        private Node<int> head;
        public CList() { }

        public CList(int a)
        {
            head = new Node<int>(a);
        }

        public CList(int[] array)
        {
            foreach (var el in array)
            {
                Add(el);
            }
        }
        /// <summary>
        /// Добавление по умолчанию в конец
        /// </summary>
        public void Add(int a)
        {
            var newNode = new Node<int>(a);

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
        /// Добавление на опредленную позицию
        /// </summary>
        public void Add(int a, int position)
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

            var newNode = new Node<int>(a);
            //если добавляем не в конец то к новому элементу записываем хвост
            if (headCopy.NextNode != null)
                newNode.NextNode = headCopy.NextNode;
            headCopy.NextNode = newNode;
        }
        /// <summary>
        /// Добавление в начало
        /// </summary>
        public void AddToHead(int a)
        {
            var newNode = new Node<int>(a);
            newNode.NextNode = head;
            head = newNode;
        }
        /// <summary>
        /// Вставляет число m до и после первого элемента, равного k
        /// </summary>
        public void PasteNumber(int k, int m)
        {
            if (head == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            if (head.InfField == k)
            {
                AddToHead(m);
                Add(m, 3);
                return;
            }
            var nodeCopy = head;
            var length = Length();
            int i = 2;
            while (nodeCopy.NextNode != null) 
            {
                if (nodeCopy.NextNode.InfField != k)
                    i++;
                else
                    break;
                nodeCopy = nodeCopy.NextNode;
            }
            if (nodeCopy.NextNode == null && i == length + 1)
            {
                Console.WriteLine("Указанного элемента не существует. Вставка невозможна.");
                return;
            }
            Add(m, i);
            Add(m, i + 2);
        }
        public int Length()
        {
            int length = 0;
            if (head != null)
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
        /// Удаление элемента на определенной позиции
        /// </summary>
        public void Delete(int position)
        {
            if (position <= 0)
                throw new Exception("Позиция предусматривает положительное число. Введите корректное значение");
            int length = Length();
            if (position > length)
                throw new Exception("Элемента на данной позиции не существует. Введите корректное значение");
            if (position == length)
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
                DeleteHead();
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
                headCopy = headCopy.NextNode;
            }
            return result.ToString();
        }
    }
    public class CListRunner
    {
        public void Run()
        {
            var a = new CList(new int[] { 1, 3, 4, 5 });
            a.PasteNumber(2, 5);
            var b = new CList(new int[] { 1, 2, 3, 4, 5 });
            b.PasteNumber(2, 5);
            Console.WriteLine(b.ToString());
            var c = new CList(new int[] { 1, 2, 3, });
            c.PasteNumber(1, 5);
            Console.WriteLine(c.ToString());
            var d = new CList(new int[] { 1 });
            d.PasteNumber(1, 5);
            Console.WriteLine(d.ToString());
        }
    }
}
