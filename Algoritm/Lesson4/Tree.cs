using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm.Lesson4
{
    public class Tree : ITree
    {
        private List<int> ListTree = new();
        private TreeNode Head;
        private int length;
        private int _maxLength;

        public Tree(int length, int NumM)
        {
            this.length = length;
            _maxLength = NumM.ToString().Length;
            Random rnd = new();
            
            for (int i = 0; i < length; i++)
            {
                ListTree.Add(rnd.Next(NumM));
            }
            ListTree.Sort();
            Head = StartTree(0, this.length);
        }

        /// <summary>
        /// Добавление нового элемента списка
        /// </summary>
        /// <param name="value">Значение нового элемента</param>
        public void AddNode(int value)
        {
            ListTree.Add(value);
            ListTree.Sort();
            length++;
            _maxLength = ListTree[ListTree.Count - 1].ToString().Length;
            Head = StartTree(0, length);
        }

        /// <summary>
        /// Ген. бинарного дерева
        /// </summary>
        private TreeNode StartTree(int left, int rigth)
        {
            //TreeNode newNode;
            if (left >= rigth)
                return null;
            else
            {
                var newNode = new TreeNode();

                var n = (rigth + left) / 2;
                newNode.Value = ListTree[n];

                newNode.LeftChild = StartTree(left, n);
                newNode.RightChild = StartTree(n + 1, rigth);
                return newNode; 
            }
          
        }

        /// <summary>
        /// Получение узла дерева по его значению
        /// </summary>
        /// <param name="value">Значение для поиска</param>
        /// <returns>Узел дерева с искомым значением либо null</returns>
        public TreeNode GetNodeByValue(int value)
        {
            if (Head == null) 
                return null;

            var tempNode = Head;
            while (true)
            {
                if (tempNode == null)
                {
                    break;
                }

                if (value == tempNode.Value)
                {
                    return tempNode;
                }
                if (value < tempNode.Value)
                {
                    tempNode = tempNode.LeftChild;
                }
                else
                {
                    tempNode = tempNode.RightChild;
                }
            }

            return tempNode;
        }

        /// <summary>
        /// Получение корня дерева
        /// </summary>
        /// <returns>Корень дерева</returns>
        public TreeNode GetRoot()
        {
            return Head;//голова
        }

        /// <summary>
        /// Вывод дерева в консоль
        /// </summary>
        public void PrintTree()
        {
            Print(Head);
        }

        /// <summary>
        /// Вывод дерева
        /// </summary>
        /// <param name="root">Корень дерева</param>
        /// <param name="p">Добавочный отступ при выводе</param>
        private void Print(TreeNode root, string p = "")
        {
            if (root != null)
            {
                Print(root.RightChild, p + new string(' ', _maxLength));
                Console.WriteLine($"{p}{root.Value}");
                Print(root.LeftChild, p + new string(' ', _maxLength));
            }
        }

        /// <summary>
        /// Удаление элемента из дерева
        /// </summary>
        /// <param name="value">Удаляемое значение</param>
          public bool RemoveItem(int value)
        {
            try
            {
                ListTree.Remove(value);
                length--;
                _maxLength = ListTree[^1].ToString().Length;
                Head = StartTree(0, length);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }
    }
}
