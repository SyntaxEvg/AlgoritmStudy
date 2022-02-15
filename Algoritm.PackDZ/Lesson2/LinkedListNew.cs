using Algoritm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm.Lesson2
{


    public class LinkedListNewClass : Ilesson
    {
        public int id { get => 1; }
        public string Descprition { get => "Двусвязный список"; }

        public void RUN()
        {
            LinkedListNew();
        }

        /// <summary>
        /// LinkedListNew работа с листом
        /// </summary>
        void LinkedListNew()
        {
            Algoritm.LInkL.LinkedList<string> ListLink = new Algoritm.LInkL.LinkedList<string>();
            //можно  и юзерам чере вввод  сделать и через Enum, но зачем  
            Console.WriteLine("Работа со списком, команды /6 Exit");
            Console.WriteLine("0) AddNode(T value); добавляет новый элемент списка");
            Console.WriteLine("1) GetCount();возвращает количество элементов в списке");
            Console.WriteLine("2) AddNodeAfter();  добавляет новый элемент списка после определённого элемента");
            Console.WriteLine("3) RemoveNode(T index); удаляет элемент по порядковому номеру");
            Console.WriteLine("4) RemoveNode(); удаляет указанный элемент");
            Console.WriteLine("5) FindNode(T searchValue); ищет элемент по его значению");
            while (true)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.D0:
                        {
                            Console.WriteLine("Добавить новый элемент списка");
                            
                           var g= CR.ConsoleReadLine();
                           var d = new AlgoritmBaseConsole().ConsoleReadLine();
                            var STR = Console.ReadLine();
                            if (STR.Length > 0)
                            {
                                ListLink.AddNode(STR);
                            }
                        }
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine($"Count List {ListLink.GetCount()}");
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        //AddNodeAfter(); добавляет новый элемент списка после определённого элемента");
                        ListLink.AddNodeAfter(ListLink.First, "Костя");
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        ListLink.RemoveNode("Евгений");//по значению 
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        ListLink.RemoveNode(ListLink.Last);//по  элементы
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        ListLink.FindNode("Николай");// ищет элемент по его значению
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        Environment.Exit(0);
                        break;
                }
            }
            Console.WriteLine("Вывод всего листа");
            foreach (var person in ListLink)
            {
                Console.WriteLine(person);
            }




        }

    }
}
