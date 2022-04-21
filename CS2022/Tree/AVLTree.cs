using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Tree
{
    public class AVLTree<T>
    {
        private BinaryTreeNode<T> root;
        public AVLTree(BinaryTreeNode<T> _root)
        {
            root = _root;
        }

        /// <summary>
        /// Малый левый поворот
        /// </summary>
        public BinaryTreeNode<T> SmallLeftTurn(BinaryTreeNode<T> r)
        {
            if (r.Right == null)
                throw new Exception("Малый левый поворот невозможен");
            var newRoot = r.Right;
            r.Right = r.Right.Left;
            newRoot.Left = r;
            r = newRoot;
            return newRoot;
        }

        /// <summary>
        /// Малый правый поворот
        /// </summary>
        public BinaryTreeNode<T> SmallRightTurn(BinaryTreeNode<T> r)
        {
            if (r.Left == null)
                throw new Exception("Малый правый поворот невозможен");
            var newRoot = r.Left;
            r.Left = r.Left.Right;
            newRoot.Right = r;
            r = newRoot;
            return newRoot;
        }

        /// <summary>
        /// Большой левый поворот
        /// </summary>
        public BinaryTreeNode<T> BigLeftTurn(BinaryTreeNode<T> r)
        {
            if (r.Right == null && r.Right.Left == null)
                throw new Exception("Большой левый поворот невозможен");
            var newRoot = r.Right.Left;
            r.Right.Left = newRoot.Right;
            newRoot.Right = r.Right;
            r.Right = newRoot.Left;
            newRoot.Left = r;
            r = newRoot;
            return newRoot;
        }

        /// <summary>
        /// Большой правый поворот
        /// </summary>
        public BinaryTreeNode<T> BigRightTurn(BinaryTreeNode<T> r)
        {
            if (r.Left == null && r.Left.Right == null)
                throw new Exception("Большой правый поворот невозможен");
            var newRoot = r.Left.Right;
            r.Left.Right = newRoot.Left;
            newRoot.Left = r.Left;
            r.Left = newRoot.Right;
            newRoot.Right = r;
            r = newRoot;
            return newRoot;
        }

        /// <summary>
        /// Подсчёт высоты поддерева
        /// </summary>
        public int Height(BinaryTreeNode<T> node)
        {
            if (node == null)
                return -1;
            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        /// <summary>
        /// Подсчёт разности высот левого и правого поддеревьев
        /// </summary>
        public int Balance(BinaryTreeNode<T> node)
        {
            if (node == null)
                return 0;
            return Height(node.Left) - Height(node.Right);
        }

        /// <summary>
        /// Добавление нового элемента в дерево с последующей балансировкой
        /// </summary>
        public void Add(int key, T value)
        {
            root = Add(root, key, value);
        }
        private BinaryTreeNode<T> Add(BinaryTreeNode<T> node, int key, T value)
        {
            if (node == null)
                return new BinaryTreeNode<T>(value, key);
            if (key < node.Key)
                node.Left = Add(node.Left, key, value);
            else if (key > node.Key)
                node.Right = Add(node.Right, key, value);
            else
                return node;
            int balance = Balance(node);
            if (balance > 1 && key < node.Left.Key)
                return SmallRightTurn(node);
            if (balance < -1 && key > node.Right.Key)
                return SmallLeftTurn(node);
            if (balance > 1 && key > node.Left.Key)
                return BigRightTurn(node);
            if (balance < -1 && key < node.Right.Key)
                return BigLeftTurn(node);
            return node;
        }

        public void BreadthFirstSearch()
        {
            List<BinaryTreeNode<T>> toVisit = new List<BinaryTreeNode<T>>();
            toVisit.Add(root);
            while (toVisit.Any())
            {
                var current = toVisit[0];
                if (current.Right != null) toVisit.Add(current.Right);
                if (current.Left != null) toVisit.Add(current.Left);
                toVisit.RemoveAt(0);
                Console.WriteLine($"Ключ: {current.Key} ");
            }
        }
    }
}
