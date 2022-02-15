using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm.Lesson2.PointStructDoubleClassOrStruct
{
    public class PointStructDoubleClassOrStructRUN : Ilesson
    {
        public int id { get => 2; }
        public string Descprition { get => "PointStructDoubleClassOrStruct"; }

        public void RUN()
        {
            BenchmarkRunner.Run<PointStructDoubleClassOrStructRUN>();
        }
        //Создаем 2 типа:d = √ (х А – х В) 2 + (у А – у В) 2)
        //* структура PointStructDouble с полями типа double (Double)
        //* класс PointClassDouble с полями типа double (Double)
        //Создаем метод, возвращающий расстояние между парой точек каждого типа.Реализуем метод,
        //создающий массив точек каждого типа и заполняющий его случайными значениями.
        //Проводим замеры длительности выполнения методов на массивах разного размера.
        //Вывод может иметь вид(соответственно x, y - время выполнения, Ratio - отношение времени):
        //Количество точек | PointStructDouble | PointClassDouble | Ratio
        //100000           | x1                | y1               | y1/x1
        //200000           | x2                | y2               | y2/x2
        [Benchmark(Description = "через class")]
        public double RunTestClass()
        {
            return PointDistanClass(RandomStructPoint(), RandomStructPoint());
        }

        [Benchmark(Description = "через Struct")]
        public double RunTestStruct()
        {
            return PointDistanDoubleStruct(RandomClassPoint(), RandomClassPoint());
        }
        public double PointDistanDoubleStruct(PointClassDouble x1, PointClassDouble y1)
        {
            var x = x1.X - y1.X;
            var y = x1.Y - y1.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public double PointDistanClass(PointStructDouble x1, PointStructDouble y1)
        {
            var x = x1.X - y1.X;
            var y = x1.Y - y1.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        static Random r = new Random();
        public static PointStructDouble RandomStructPoint()
        {

            var xD = r.NextDouble();
            var yD = r.NextDouble();
            PointStructDouble point = new()
            {
                X = xD,
                Y = yD
            };
            return point;
        }
        public static PointClassDouble RandomClassPoint()
        {

            double x = r.NextDouble();
            double y = r.NextDouble();
            PointClassDouble point = new()
            {
                X = x,
                Y = y
            };
            return point;
        }

    }
}
