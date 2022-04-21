using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Tree
{
    public class TreeNode<T>
    {
        public T Value;
        List<TreeNode<T>> childNodeList;
        public List<TreeNode<T>> ChildNodeList
        {
            get => childNodeList;
        }
        public TreeNode(T value)
        {
            this.Value = value;
        }
        public TreeNode(T value, List<TreeNode<T>> children)
        {
            this.Value = value;
            childNodeList = children;
        }
        public void AddChild(T value)
        {
            if( childNodeList == null)
                childNodeList = new List<TreeNode<T>>();
            childNodeList.Add(new TreeNode<T>(value));
        }
        public bool HasChild()
        {
            return ChildNodeList?.Any() ?? false;
        }

        int maxvalue = Int32.MinValue;

        //public  void InfixMax(BinaryTreeNode<int> tree, ref int maxvalue)
        //{
        //    if (tree == null) return;
        //    if (tree.LeftChild != null)
        //    {
        //        if (tree.Value > maxvalue)
        //            maxvalue = tree.LeftChild.Value;
        //        InfixMax(tree.LeftChild, ref maxvalue);
        //    }
        //    if (tree.Value > maxvalue)
        //        maxvalue = tree.Value;
        //    if (tree.RightChild != null)
        //        InfixMax(tree.RightChild, ref maxvalue);
        //}
        //public void Run()
        //{
        //    int maxvalue = Int32.MinValue;
        //    InfixMax(head, ref maxvalue);
        //}
    }
}
