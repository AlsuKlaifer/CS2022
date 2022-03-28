﻿using System;
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
        public List<TreeNode<T>> ChildNodeList { get => childNodeList;  }
        public TreeNode(T value)
        {
            Value = value;
        }
        public TreeNode(T value, List<TreeNode<T>> children)
        {
            Value = value;
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
    }
}
