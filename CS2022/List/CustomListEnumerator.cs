using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS2022.List
{
    public class CustomListEnumerator<T> : IEnumerator<T>
    {
        /// <summary>
        /// Начало списка, по которому пройдемся
        /// </summary>
        private Node<T> _head;
        /// <summary>
        /// Текущий узел при проходе по списку
        /// </summary>
        private Node<T> current;

        public CustomListEnumerator(Node<T> head)
        {
            _head = head;
        }

        public T Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (current.NextNode != null)
            {
                current = current.NextNode;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            current = new Node<T>(default(T))
            {
                NextNode = _head
            };
        }
    }
}
