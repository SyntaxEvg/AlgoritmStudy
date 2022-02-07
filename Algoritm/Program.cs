
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
      
        List<Ilesson> TaskDZ = null;
        MGetTasks(out TaskDZ);//при появление новых дз дописывать в этот метод

        Console.WriteLine($"Выбрать задания от {TaskDZ.First().id} до {TaskDZ.Count-1} или {TaskDZ.Last().id}- если хотите выйти из программы");
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

    static void MGetTasks(out List<Ilesson> TaskDZ)
    {
        TaskDZ = new()
        {
            new LinkedListNewClass(),
            new PointStructDoubleClassOrStructRUN(),
            new HashSetClass(),
            new TreeClass(),
            //служебный класс его не учитываем в реализации
            new ExitClass(),

        };
    }
}
