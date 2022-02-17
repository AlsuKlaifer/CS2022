using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.List
{
    public class Node
    {
        /// <summary>
        /// Информационное поле
        /// </summary>
        public int InfField;
        /// <summary>
        /// Ссылка на следующий элемент
        /// </summary>
        public Node NextNode;
        /// <summary>
        /// Конструктор
        /// </summary>
        public Node(int a)
        {
            InfField = a;
        }
    }
}
