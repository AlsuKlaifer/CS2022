using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CS2022.Tree;
using AISD.SemesterWork2;

namespace TreeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void HATRun()
        {
            var hat = new HashedArrayTree<int>();
            hat.Add(1);
            hat.Add(2);
            hat.Add(3);
            hat.Add(4);
            Assert.AreEqual(hat.Count, 4);
            Assert.AreEqual(hat[0], 1);
            Assert.AreEqual(hat[1], 2);
            Assert.AreEqual(hat[2], 3);
            Assert.AreEqual(hat[3], 4);
            hat.Add(5);
            Assert.AreEqual(hat.Capacity, 16);
            Assert.AreEqual(hat.Count, 5);
            hat.Add(6);
            hat.Add(7);
            hat.Add(7);
            hat.Remove(7);
            Assert.AreEqual(hat[5], 6);
            Assert.AreEqual(hat[6], 7);
            hat.Add(8);
            hat.Add(9);
            hat.RemoveAt(7);
            Assert.AreEqual(hat[7], 9);
            hat.Insert(7, 8);
            Assert.AreEqual(hat[7], 8);
            Assert.AreEqual(hat[8], 9);
            Assert.IsTrue(hat.Contains(6));
        }
        //public void TestMethod1()
        //{
        //    var tree = new BinarySearchTree<string>();
        //    tree.Add(8, "a");
        //    tree.Add(3, "c");
        //    tree.Add(10, "c");
        //    tree.Add(1, "c");
        //    tree.Add(5, "c");
        //    tree.Add(14, "c");
        //    tree.Add(4, "c");
        //    tree.Add(6, "c");
        //    tree.Add(13, "c");
        //    tree.Add(7, "c");
        //    tree.BreadthFirstSearch();

        //    Assert.IsTrue(tree.IsKeyExists(5));
        //    tree.Remove(5);
        //    tree.BreadthFirstSearch();
        //    Assert.IsFalse(tree.IsKeyExists(5));

        //    Assert.IsTrue(tree.IsKeyExists(14));
        //    tree.Remove(14);
        //    tree.BreadthFirstSearch();
        //    Assert.IsFalse(tree.IsKeyExists(14));
        //}
    }
}