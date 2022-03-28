using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Tree
{
    public class TreeRunner
    {
        var n8 = new TreeNode<int>(8);
        var n9 = new TreeNode<int>(9);
        var n5 = new TreeNode<int>(5, new List<TreeNode<int>>() { n8, n9 });
        var n6 = new TreeNode<int>(6);
        var n7 = new TreeNode<int>(7);
        var n2 = new TreeNode<int>(2, new List<TreeNode<int>>() { n5, n6 });
        var n3 = new TreeNode<int>(3);
        var n4 = new TreeNode<int>(4, new List<TreeNode<int>>() { n7 });
        var n1 = new TreeNode<int>(1, new List<TreeNode<int>>() { n2, n3, n4 });
    }
}
