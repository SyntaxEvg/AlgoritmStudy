
using Algoritm;
using Algoritm.Common;
using Algoritm.Lesson2;
using Algoritm.Lesson2.PointStructDoubleClassOrStruct;
using BenchmarkDotNet.Running;
using GeekBrainsTests;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

internal class Program
{
    public static IConsole_ReadLine CR = new AlgoritmBaseConsole();
    static void Main(string[] args)
    {  
        //получаем все дз что у нас есть 
        //Ilesson  ilesson = null;
        List<Ilesson> TaskDZ = new();
        //если что-то не работает положить все в папку с прогой 
        Assembly  assembly = Assembly.LoadFrom("Algoritm.PackDZ.dll");
        string NameInterface = "Ilesson";
        Ilesson ilesson;
        if (assembly is not null)
        {
            var types = assembly.GetTypes();//.Select(x => x.);
            foreach (Type type in types)
            {
                foreach (Type item in type.GetInterfaces())
                {
                    var t =item is Ilesson;
                    //if (t)
                    if (item.Name == NameInterface)
                    {
                        Console.WriteLine(type.FullName);

                        Ilesson ClassTypeLib = (Ilesson)Activator.CreateInstance(type);
                        if (ClassTypeLib is not null)
                        {
                            GetTaskss(ref TaskDZ, ClassTypeLib);////при появление новых дз дописывать в этот метод
                        }
                       

                    }
                }
               
            }          
        }
        else
        {
            return;
        }
      
        Console.WriteLine($"Выбрать задания от {TaskDZ.First().id} до {TaskDZ.Count - 1} или {TaskDZ.Last().id}- если хотите выйти из программы");
        foreach (var item in TaskDZ)
        {
            Console.WriteLine($"{item.id}){item.Descprition}");
        }
        while (true)
        {            
            int count = Program.CR.TryParseCR();
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

    //static void GetTasks(out List<Ilesson> TaskDZ)
    //{
    //    TaskDZ = new()
    //    {
    //        new LinkedListNewClass(),
    //        new PointStructDoubleClassOrStructRUN(),
    //        new HashSetClass(),
    //        new TreeClass(),
    //        new DFSandBFS(),
    //        //служебный класс его не учитываем в реализации
    //        new ExitClass(),

    //    };
    //}
    static void GetTaskss<T>(ref List<Ilesson> TaskDZ, T ClassTypeLib) where T:Ilesson
    {
        TaskDZ.Add(ClassTypeLib);
    }
}
