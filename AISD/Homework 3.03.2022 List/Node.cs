using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.List
{
    public class Node<T>
    {
        /// <summary>
        /// Информационное поле
        /// </summary>
        public T InfField;
        /// <summary>
        /// Ссылка на следующий элемент
        /// </summary>
        public Node<T> NextNode;
        /// <summary>
        /// Конструктор
        /// </summary>
        public Node(T a)
        {
            InfField = a;
        }
    }
}
