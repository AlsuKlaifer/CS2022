using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CS2022.Tree;
namespace TreeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var tree = new BinarySearchTree<string>();
            tree.Add(8, "a");
            tree.Add(3, "c");
            tree.Add(10, "c");
            tree.Add(1, "c");
            tree.Add(5, "c");
            tree.Add(14, "c");
            tree.Add(4, "c");
            tree.Add(6, "c");
            tree.Add(13, "c");
            tree.Add(7, "c");
            tree.BreadthFirstSearch();

            Assert.IsTrue(tree.IsKeyExists(5));
            tree.Remove(5);
            tree.BreadthFirstSearch();
            Assert.IsFalse(tree.IsKeyExists(5));

            Assert.IsTrue(tree.IsKeyExists(14));
            tree.Remove(14);
            tree.BreadthFirstSearch();
            Assert.IsFalse(tree.IsKeyExists(14));
        }
    }
}