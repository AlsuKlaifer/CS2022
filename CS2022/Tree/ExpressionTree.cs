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
        private BinaryTreeNode<string> head;
        public ExpressionTree(BinaryTreeNode<string> _head)
        {
            head = _head;
        }
        /// <summary>
        /// Вычисление всего выражения
        /// </summary>
        public double Calc()
        {
            Calc(head);
            return Convert.ToDouble(head.Value);
        }
        private void Calc(BinaryTreeNode<string> root)
        {
            if ((IsOper(root.Value) && root.Left.Value== null) || (IsOper(root.Value) && root.Right.Value == null))
                Console.WriteLine("Невозможно совершить операцию");
            if (!IsOper(root.Value)) //если число, то ничего не делаем
                return;
            if (IsOper(root.Left.Value)) //если левый ребенок операция
                Calc(root.Left);
            if (IsOper(root.Right.Value))
                Calc(root.Right);
            //если рут операция
            root.Value = Convert.ToString(Calc(root.Value, Convert.ToDouble(root.Left.Value),
                Convert.ToDouble(root.Right.Value)));
            root.Left = null;
            root.Right = null;
        }

        /// <summary>
        /// Вычисление одного действия
        /// </summary>
        private double Calc(string charOp, double a, double b)
        {
            //получаю действие, соответствующее charOp
            var op = GetOperation(charOp);

            return op(a, b);
        }

        /// <summary>
        /// по символу возвращает действие (бинарную операцию)
        /// </summary>
        /// <returns></returns>
        private BinOper GetOperation(string charOp)
        {
            if (operDict.TryGetValue(charOp, out var op))
                return op;
            else throw new InvalidOperationException(
                $"Операции, соотв-ей символу {charOp} не существует");
        }
        private bool IsOper(string symbol)
        {
            return operDict.ContainsKey(symbol);
        }

        private Dictionary<string, BinOper> operDict =
            new Dictionary<string, BinOper>()
            {
                {"*", (a, b) => a * b },
                {"+",  SumVal},
                {"-", (a, b) => a - b },
                {"/", (a, b) => a / b }
            };

        private static double SumVal(double a, double b)
        {
            return a + b;
        }

    }
    /// <summary>
    /// Тип делегата бинарная операция
    /// </summary>
    /// <param name="a">пар-р 1</param>
    /// <param name="b">пар-р 2</param>
    /// <returns>результат</returns>
    public delegate double BinOper(double a, double b);
}

