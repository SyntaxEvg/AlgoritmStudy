using Algoritm;
using Algoritm.Common;
using Algoritm.Lesson4;
using System.Diagnostics;

public class TasksНumberОptions : Ilesson
{
    static int[] ArrayINT;
    public int id => 7;
    public string Descprition => "7)Реализовать алгоритм\n[задачи на количество вариантов]\n" +
        "и вывод количества вариантов\n" +
        " для последовательности [1..100]";

    public void RUN()
    {
        Stopwatch stopwatch = new();
        int numM = 0;
        Console.WriteLine("1_Рекурсия\n2_Не рекурсивный подход");
        while (true)
        {
            var a = String.Intern(Console.ReadLine());
            int.TryParse(a, out numM);
            if (numM > 0 && numM == 1)
            {
                stopwatch = new();
                stopwatch.Start();
                AlgoritmRecurs100number();
                stopwatch.Stop();
                OutConsoleElipsoid(ref stopwatch);
                break;
            }
            else if (numM > 0 && numM == 2)
            {
                stopwatch = new();
                stopwatch.Start();
                AlgoritmNoRecurs100number();
                stopwatch.Stop();
                OutConsoleElipsoid(ref stopwatch);
                break;
            }
        }
    }

    private void OutConsoleElipsoid(ref Stopwatch stopwatch)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{stopwatch.Elapsed}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    ///  вывод количества вариантов для последовательности Рекурсивный
    /// </summary>
    static void AlgoritmRecurs100number()
    {
        ArrayINT = new int[101];
        int num = 0;
        while (true)
        {
            if (num == 100)
            {
                break;
            }
            ArrayINT[num] = 0;
            num++;
        }
        num = 1;
        while (true)
        {
            if (num == 101)
            {
                break;
            }
            Console.WriteLine($"num ={num}\t OutOption ={Recursive_method(num)}");
            num++;
        }


    }
    static int Recursive_method(int num)
    {
        if (ArrayINT[num] == 0)
            if (num == 1)
                ArrayINT[num] = 1;
            else
                ArrayINT[num] = Recursive_method(num - 1) + ((num % 2 == 0) ? Recursive_method(num / 2) : 0);
        return ArrayINT[num];
    }
    /// <summary>
    /// вывод количества вариантов для последовательности Без Рекурсивный
    /// </summary>
    static void AlgoritmNoRecurs100number()
    {
        ArrayINT = new int[101];
        for (int i = 0; i <= 100; i++)
        {
            ArrayINT[i] = 0;
        }
        ArrayINT[1] = 1;
        for (int i = 1; i <= 100; i++)
        {
            if (i > 1)
            {
                ArrayINT[i] = ArrayINT[i - 1] + ((i % 2 == 0) ? ArrayINT[i / 2] : 0);//если чет или ноль 
            }
            Console.WriteLine($"num ={i}\t OutOption ={ArrayINT[i]}");
        }
    }


}