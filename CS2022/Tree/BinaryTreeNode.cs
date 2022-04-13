using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Tree
{
    /// <summary>
    /// Вершина бинарного дерева поиска
    /// </summary>
    public class BinaryTreeNode<T>
    {
        public T Value;
        public int Key;
        public BinaryTreeNode<T> Left;
        public BinaryTreeNode<T> Right;
        public BinaryTreeNode<T> Parent;

        public BinaryTreeNode(T value, int key, BinaryTreeNode<T> parent = null)
        {
            Value = value;
            Key = key;
        }

        public BinaryTreeNode(T value, int key, BinaryTreeNode<T> left, BinaryTreeNode<T> right, BinaryTreeNode<T> parent = null)
        {
            Value = value;
            Key = key;
            Parent = parent;
            Right = right;
            Left = left;
        }
    }
}
