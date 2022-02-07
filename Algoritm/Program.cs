
using Algoritm;
using Algoritm.Lesson2;
using Algoritm.Lesson2.PointStructDoubleClassOrStruct;
using BenchmarkDotNet.Running;
using GeekBrainsTests;
using System.Collections.Concurrent;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        //получаем все дз что у нас есть 
        //Ilesson  ilesson = null;
        List<Ilesson> TaskDZ = new();
        TaskDZ.Add(new LinkedListNewClass());
        TaskDZ.Add(new PointStructDoubleClassOrStructRUN());
        Console.WriteLine($"Выбрать задания от 1 до {TaskDZ.Count} или {new ExitClass().id}- если хотите выйти из программы");
        foreach (var item in TaskDZ)
        {
            Console.WriteLine($"{item.id}){item.Descprition}");
        }
        while (true)
        {
            var temp = Console.ReadLine();
            int count = 0;
            int.TryParse(temp, out count);
            if (count != 0)
            {
                var ok = TaskDZ.FirstOrDefault(x => x.id == count);

               
                if (ok is not null)
                {
                    ok.RUN();

                }
                else
                    Console.WriteLine("Not DZ");

            }
        }
    }
}
