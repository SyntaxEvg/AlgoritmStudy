using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text.RegularExpressions;
internal class PointStructDoubleClass
{

    public PointStructDoubleClass()
    {
        BenchmarkSwitcher.FromAssembly(typeof(PointStructDoubleClass).Assembly).Run();
    }

//Создаем 2 типа:
//* структура PointStructDouble с полями типа double (Double)
//* класс PointClassDouble с полями типа double (Double)
//Создаем метод, возвращающий расстояние между парой точек каждого типа.Реализуем метод,
//создающий массив точек каждого типа и заполняющий его случайными значениями.
//Проводим замеры длительности выполнения методов на массивах разного размера.
//Вывод может иметь вид(соответственно x, y - время выполнения, Ratio - отношение времени):
//Количество точек | PointStructDouble | PointClassDouble | Ratio
//100000           | x1                | y1               | y1/x1
//200000           | x2                | y2               | y2/x2
    
        class PointStructDouble
        {

        }
         struct PointClassDouble
         {

         }   

}