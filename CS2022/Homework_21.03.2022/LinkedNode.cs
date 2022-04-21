using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS2022.List;

namespace CS2022.Homework_21._03._2022
{
    /// <summary>
    /// Элемент двунаправленного связного списка
    /// </summary>
    public class LinkedNode<T> where T : IComparable<T>
    {
        /// <summary>
        /// Информационное поле
        /// </summary>
        public T InfField;
        /// <summary>
        /// Следующий элемент
        /// </summary>
        public LinkedNode<T> NextNode;
        /// <summary>
        /// Предыдущий элемент
        /// </summary>
        public LinkedNode<T> PrevNode;
        public LinkedNode(T inf)
        {
            InfField = inf;
        }
    }
}
