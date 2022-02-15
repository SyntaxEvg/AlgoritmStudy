using Algoritm;
using Algoritm.Common;
using Algoritm.Lesson4;

public class DFSandBFS : Ilesson
{
    public static IConsole_ReadLine CR = new AlgoritmBaseConsole();
    //Реализуйте класс двоичного дерева поиска с операциями вставки, удаления, поиска.
    ///Дерево должно быть сбалансированным(это требование не обязательно).
    /// Также напишите метод вывода в консоль дерева, чтобы увидеть, насколько корректно работает ваша реализация.
    public int id => 5;
    public string Descprition => "5)Реализуйте методы поиска в дереве поиск в ширину и поиск в глубину (класс дерева должен быть реализован в ДЗ урока 4) с выводом каждого шага в консоль.";

    public void RUN()
    {
        int l = 0;    // количество элементов дерева
        int numM = 0;       // максимальное значение в дереве

        Console.WriteLine("Требуется два параметра введи их через  пробел\nколичество элементов дерева\nмаксимальное значение в дереве");
        while (true)
        {
            var a = String.Intern(Console.ReadLine());
            var spitStr = a.Split(' ');
            if (spitStr.Length == 2)
            {
                int.TryParse(spitStr[0], out l);
                int.TryParse(spitStr[1], out numM);
                if (l > 0 && numM > 0)
                {
                    Tree(ref l, ref numM);
                }

            }
            else
            {
                Console.WriteLine($"error Length: {a}");
            }
        }
    }

    private void Tree(ref int l, ref int numM)
    {
        Tree tree = new(l, numM);
        Console_WCommands();   
        while (true)
        {
            var a = Console.ReadKey();
            switch (a.Key)
            {
                case ConsoleKey.D0:
                    tree.PrintTree();
                    break;
                case ConsoleKey.D1:
                    AddNode(tree);
                    break;
                case ConsoleKey.D2:
                    Remove_node(tree);
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine($"Root Tree: {tree.GetRoot().Value}");
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("Что ищем?");
                    SearchValue(tree);
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine("поиск в ширину");//BFS
                    BFS(tree);
                    break;
                case ConsoleKey.D6:
                    Console.WriteLine("поиск в глубину");//deep-first search DFS
                    DFS(tree);
                    break;
                default:
                    break;
            }
        }
        Console.ReadKey();
    }

    private void Console_WCommands()
    {
        Console.WriteLine("Commands");
        Console.WriteLine("0)Показать дерево");
        Console.WriteLine("1)add node");
        Console.WriteLine("2)Remove node");
        Console.WriteLine("3)Get node on");
        Console.WriteLine("4)Seacrh Item");
        Console.WriteLine("5)поиск в ширину");
        Console.WriteLine("6)поиск в глубину");
    }

    /// <summary>
    /// поиск в глубину
    /// </summary>
    /// <param name="tree"></param>
    private void DFS(Tree tree)
    {
        foreach (var number in ConsoleReadLineTree())
        {
            var node = tree.SearhDFS(number);
            if (node is not null)
            {
                Console.WriteLine($"Найденно значение {node.Value}");
            }
        }
    }
    /// <summary>
    /// поиск в ширину
    /// </summary>
    /// <param name="tree"></param>
    private void BFS(Tree tree)
    {
        foreach (var number in ConsoleReadLineTree())
        {
            var node = tree.GetNodeByValue(number);
            if (node is not null)
            {
                Console.WriteLine($"Найденно значение {node.Value}");
            }
        }
    }

    IEnumerable<int> ConsoleReadLineTree()//одинаковы метод для трех поз
    {
        var s = String.Intern(Console.ReadLine());
        var spitStr = s.Split(' ');
        int number = 0;
        foreach (var n in spitStr)
        {
            int.TryParse(n, out number);
            yield return number;
            number = 0;
        }
    }

    /// <summary>
    /// получить узел дерева по значению
    /// </summary>
    /// <param name="tree"></param>
    private void SearchValue(Tree tree)
    {
        foreach (var number in ConsoleReadLineTree())
        {
            var node = tree.GetNodeByValue(number);
            if (node is not null)
            {
                Console.WriteLine($"Найденно значение {node.Value}");
            }
        }
    }

    private void Remove_node(Tree tree)
    {
        Console.WriteLine("Пишем через пробел что хотим удалить и жмем enter");
        while (true)
        {
            var s = String.Intern(Console.ReadLine());
            var spitStr = s.Split(' ');

            int number = 0;
            foreach (var n in spitStr)
            {
                int.TryParse(n, out number);
                var r = tree.GetNodeByValue(number);
                if (r is not null)
                {
                    if (tree.RemoveItem(number))
                    {
                        Console.WriteLine($"Deleted {number}");
                        number = 0;
                    }
                }

            }
            return;
        }

    }

    private void AddNode(Tree tree)
    {
        Console.WriteLine("Пишем через пробел и жмем enter");
        while (true)
        {
            var s = String.Intern(Console.ReadLine());
            var spitStr = s.Split(' ');
            int number = 0;
            foreach (var n in spitStr)
            {
                int.TryParse(n, out number);
                tree.AddNode(number);
                number = 0;
            }
            return;

        }
    }
}