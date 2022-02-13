using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm.Lesson2
{
    public class HashSetClass : Ilesson
    {
        //    Протестируйте поиск строки в HashSet и в массиве
        //    Заполните массив и HashSet случайными строками, не менее 10 000 строк.
        //    Строки можно сгенерировать.
        //    Потом выполните замер производительности проверки наличия строки в массиве и HashSet.
        //    Выложите код и результат замеров.
        public int id { get => 3; }
        public string Descprition { get => "4_1)HashSet"; }
        HashSet<string> hashSet = new HashSet<string>();
        public static int MaxStringa = 10000;
        public static string[] RandStringToArray = new string[MaxStringa];
        public static string RandomString = null;
        public static readonly Random random = new Random();
        public void RUN()
        {
            BenchmarkRunner.Run<HashSetClass>();
        }
        public string RUNTest()
        {    
            for (int i = 0; i < MaxStringa; i++)
            {
                hashSet.Add(Path.GetRandomFileName());
            }
            RandStringToArray= hashSet.ToArray();
            return hashSet.ElementAt(random.Next(hashSet.Count));
        }
        [Benchmark(Description = "Search string an array string ")]
        public void SearchString()
        {

            for (int i = 0; i < MaxStringa; i++)
            {
                if (RandStringToArray[i]==RUNTest() ) { };
            }
        }
        [Benchmark(Description = "Search string in hash ")]
        public void SearchHash()
        {
            hashSet.Contains(RUNTest());
        }



    }
}
