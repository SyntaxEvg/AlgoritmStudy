
using GeekBrainsTests;
using System.Collections.Concurrent;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    { 
      
        Console.WriteLine("Выбрать задания от 1 до 1 или 6- если хотите выйти из программы");
        Console.WriteLine("1)Двусвязный список");
        while (true)
        {
            var temp = Console.ReadLine();
            int count = 0;
            int.TryParse(temp, out count);
            if (count != 0)
            {
                switch (count)
                {
                    case 1:
                        // Двусвязный список
                        LinkedListNew();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }

        }





    }
    /// <summary>
    /// LinkedListNew работа с листом
    /// </summary>
    public static void LinkedListNew()//можно юзать  и другой сборки  
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



        ListLink.AddNode("Евгений");
        ListLink.AddNode("Cерафим");
        ListLink.AddNode("Алик");
        ListLink.AddNode("Кира");
        ListLink.AddNode("Сергей");
        int count = ListLink.GetCount();//// возвращает количество элементов в списке
        ListLink.AddNodeAfter(ListLink.First, "Костя");
        ListLink.RemoveNode("Евгений");//по значению 
        ListLink.RemoveNode(ListLink.Last);//по  элементы
        ListLink.FindNode("Николай");// ищет элемент по его значению
        count = ListLink.GetCount();//// возвращает количество элементов в списке
        foreach (var person in ListLink)
        {
            Console.WriteLine(person);
        }




    }
}
