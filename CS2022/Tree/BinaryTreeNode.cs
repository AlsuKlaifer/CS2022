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
        T Value;
        BinaryTreeNode<T> LeftChild;
        BinaryTreeNode<T> RightChild;
    }
}
