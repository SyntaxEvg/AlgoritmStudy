using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm.Lesson2
{
    internal class HashSetClass : Ilesson
    {
        //    Протестируйте поиск строки в HashSet и в массиве
        //    Заполните массив и HashSet случайными строками, не менее 10 000 строк.
        //    Строки можно сгенерировать.
        //    Потом выполните замер производительности проверки наличия строки в массиве и HashSet.
        //    Выложите код и результат замеров.
        public int id { get => 3; }
        public string Descprition { get => "4_1)HashSet"; }

        public void RUN()
        {
            var hashSet = new HashSet<string>();
            Stopwatch    stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 10001; i++)
            {               
               hashSet.Add(Path.GetRandomFileName());              
            }
            stopwatch.Stop();
            Console.WriteLine($"Add hashSet {hashSet.Count()} time -[{stopwatch.Elapsed.TotalMilliseconds}]");

        }



    }
}
