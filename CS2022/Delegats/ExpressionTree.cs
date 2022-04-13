using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.Tree
{
    /// <summary>
    /// Дерево арифметических выражений
    /// </summary>
    public class ExpressionTree
    {
        private BinaryTreeNode<char> head;
        public ExpressionTree(BinaryTreeNode<char> _head)
        {
            head = _head;
        }

        /// <summary>
        /// Вычисление всего выражения
        /// </summary>
        public double Calc()
        {

        }
        /// <summary>
        /// Вычисление одного действия
        /// </summary>
        private double Calc(char charOp, double a, double b)
        {
            //получаю действие соответсвующее charOp
            var op = GetOperation(charOp);
            return op(a, b);
        }
        private BinOper GetOperation(char charOp)
        {
            if (operDict.TryGetValue(charOp, out var op))
                return op;
            else throw new InvalidOperationException();
        }
        private Dictionary<char, BinOper> operDict =
            new Dictionary<char, BinOper>()
            {
                {'*', (a, b) => a*b },
                {'+', Sum },
                {'-', (a, b) => a-b },
                {'/', (a, b) => a/b },

            };
        private static double Sum(double a, double b)
        {
            return a + b;
        }
        /// <summary>
        /// тип делегата бинарная операция
        /// </summary>
        public delegate double BinOper(double a, double b);
    }
}
