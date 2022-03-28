using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Tree
{
    public class TreeUtils<T>
    {
        public static void BreadthFirstSearch(TreeNode<T> root)
        {
            List<TreeNode<T>> toList = new List<TreeNode<T>>();
            toList.Add(root);
            while (toList.Any())
            {
                var current = toList.First();
                toList.RemoveAt(0);
                if (current.HasChild())
                    toList.AddRange(current.ChildNodeList);
                Console.WriteLine(current.Value.ToString());
            }
        }

    }
}
