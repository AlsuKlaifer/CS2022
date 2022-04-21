using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CS2022.Homework_21._03._2022
{
    public class LinkedListEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        private LinkedNode<T> _head;

        private LinkedNode<T> currentNode;
        public T Current => currentNode.InfField;
        object IEnumerator.Current => Current;

        public LinkedListEnumerator(LinkedNode<T> head)
        {
            _head = head;
            currentNode = new LinkedNode<T>(default(T))
            {
                NextNode = head
            };
        }

        public bool MoveNext()
        {
            if (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
                return true;
            }
            else
                return false;
        }
        public void Reset()
        {
            currentNode = new LinkedNode<T>(default(T))
            {
                NextNode = _head
            };
        }

        public void Dispose()
        {
            return;
        }
    }
}