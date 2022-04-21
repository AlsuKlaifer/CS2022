using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS2022.Delegats;

namespace CS2022.Tree
{
    public class TreeRunner
    {
        public void Run()
        {
            //var binary = new BinarySearchTree<int>();
            //binary.Add(3, 3);
            //binary.Add(1, 1);
            //binary.Add(2, 2);
            //binary.Add(6, 6);
            //binary.Add(5, 5);

            //binary.BreadthFirstSearch();

            //for (int i = 0; i < 8; i++)
            //{
            //    binary.IsExternal(i);
            //}

            //binary.Remove(1);
            //binary.BreadthFirstSearch();

            var head = new BinaryTreeNode<string>("+", 1);
            head.Left = new BinaryTreeNode<string>("2", 2);
            head.Right = new BinaryTreeNode<string>("3", 3);
            var extree = new ExpressionTree(head);
            extree.Calc();
            Console.WriteLine(head.Value);

            var root = new BinaryTreeNode<int>(10, 10);
            var avl = new AVLTree<int>(root);
            avl.Add(5, 5);
            avl.Add(15, 15);
            avl.Add(1, 1);
            avl.Add(11, 11);
            avl.Add(18, 18);
            avl.Add(16, 16);
            avl.Add(23, 23);
            avl.BreadthFirstSearch();
            avl.Add(17, 17);
            avl.BreadthFirstSearch();
        }
    }
}
