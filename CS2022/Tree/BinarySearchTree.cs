using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Tree
{
    public class BinarySearchTree<T>
    {
        public BinaryTreeNode<T> root;
        private bool isFind = false;
        public void Add(int key, T value)
        {
            if (root == null) root = new BinaryTreeNode<T>(value, 1);
            else
            {
                var rootCopy = root;
                while (isFind == false)
                {
                    if (key == rootCopy.Key)
                    {
                        rootCopy.Value = value;
                        isFind = true;
                    }
                    else if (key > rootCopy.Key)
                    {
                        if (rootCopy.Left == null)
                        {
                            rootCopy.Left = new BinaryTreeNode<T>(value, key, rootCopy);
                            isFind = true;
                        }
                        else rootCopy = rootCopy.Left;
                    }
                    else
                    {
                        if (rootCopy.Right == null)
                        {
                            rootCopy.Right = new BinaryTreeNode<T>(value, key, rootCopy);
                            isFind = true;
                        }
                        else rootCopy = rootCopy.Right;
                    }

                }
            }
        }

        public void BreadthFirstSearch()
        {
            List<BinaryTreeNode<int>> toVisit = new List<BinaryTreeNode<int>>();
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

        public void InfixTraverse()
        {
            InfixTraverse();
        }

        public void PrefixSum(BinaryTreeNode<int> tree, ref int sum)
        {
            if (tree == null)
                //sum += root.Value;
            else
                    {
                        if (tree.Left != null) PrefixSum(tree.Left, ref sum);
                        if (tree.Right != null) PrefixSum(tree.Right, ref sum);
                    }

        }
        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="value">удаляемое значение</param>
        public void Remove(int key)
        {
            if (root == null)
            {
                Console.WriteLine("Дерево пусто");
                return;
            }
            Remove(key, root);
        }

        private void Remove(int key, BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                Console.WriteLine($"Элемент {key} в дереве отсутствует");
                return;
            }
            //Проверяем, надо ли искать в левом поддереве
            if (root.Key > key)
            {
                if (root.Left == null)
                {
                    Console.WriteLine($"Элемент {key} в дереве отсутствует");
                    return;
                }
                else
                    Remove(key, root.Left);
            }
            else if (root.Key < key)
            {
                if (root.Right == null)
                {
                    Console.WriteLine($"Элемент {key} в дереве отсутствует");
                    return;
                }
                else
                    Remove(key, root.Right);
            }
            else //root.Key == key - нашли узел, которы надо удалить
            {
                bool? isLeft = root.Parent != null
                    ? root.Parent.Key > root.Key
                    : (bool?)null; //нет родительского элемента - не может быть левыйм или правым
                //Если обоих детей нет, то удаляем текущий узел и 
                //обнуляем ссылку на него у родительского узла
                if (root.Left == null && root.Right == null)
                {
                    if (root.Parent != null) //isLeft.HasValue
                    {
                        if (isLeft.Value)
                            root.Parent.Left = null;
                        else
                            root.Parent.Right = null;
                    }
                    else
                        this.root = null;
                }
                //Если одного из детей нет, то значения полей 
                //ребёнка m ставим вместо соответствующих значений 
                //корневого узла, затирая его старые значения, 
                //и освобождаем память, занимаемую узлом m;
                else if (root.Left != null && root.Right == null)
                {
                    //левый потомок есть, правого нет
                    if (isLeft.HasValue) //имеется родительский элемент
                    {
                        if (isLeft.Value)
                            root.Parent.Left = root.Left;
                        else
                            root.Parent.Right = root.Left;
                    }
                    else
                        this.root = root.Left;
                }
                else if (root.Left == null && root.Right != null)
                {
                    //правый потомок есть, левого нет
                    if (isLeft.HasValue)
                    {
                        if (isLeft.Value)
                            root.Parent.Left = root.Right;
                        else
                            root.Parent.Right = root.Right;
                    }
                    else
                        this.root = root.Right;
                }
                //оба потомка имеются
                else
                {
                    //Если левый узел m правого 
                    //поддерева отсутствует(n->right->left)
                    if (root.Right.Left == null)
                    {
                        //Копируем из правого узла в удаляемый поля K, V 
                        //и ссылку на правый узел правого потомка.
                        root.Key = root.Right.Key;
                        root.Value = root.Right.Value;
                        root.Right = root.Right.Right;
                        if (root.Right != null)
                            root.Right.Parent = root;
                    }
                    else
                    {
                        //Возьмём самый левый узел m, правого поддерева n->right;
                        var mostLeft = root.Right;
                        while (mostLeft.Left != null)
                            mostLeft = mostLeft.Left;
                        //Скопируем данные (кроме ссылок на дочерние элементы) из m в n
                        root.Key = mostLeft.Key;
                        root.Value = mostLeft.Value;
                        //удалим узел m.
                        mostLeft.Parent.Left = null;
                    }
                }
            }
        }
        public bool IsKeyExists(int key)
        {
            return IsKeyExists(key, root);
        }
        private bool IsKeyExists(int key, BinaryTreeNode<T> root)
        {
            if (root == null)
                return false;
            if (root.Key == key)
                return true;
            else if (root.Key > key && root.Left != null)
            {
                return IsKeyExists(key, root.Left);
            }
            else if (root.Key < key && root.Right != null)
            {
                return IsKeyExists(key, root.Right);
            }
            else
                return false;
        }
    }
}
