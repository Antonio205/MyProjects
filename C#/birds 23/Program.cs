using System;

namespace Birds
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                    Bird bird;
                bird = new Budgie("Кеша");
                if (bird.ISwim)
                {
                    bird.ToSwim();
                }
                if (bird.IFly)
                {
                    bird.ToFly();
                }
                Bird bird1;
                bird1 = new Penguin("Ковальски");
                if (bird1.ISwim)
                {
                    bird1.ToSwim();
                }
                if (bird1.IFly)
                {
                    bird1.ToFly();
                }
                Bird bird2;
                bird2 = new Duck("Дональд");
                if (bird2.ISwim)
                {
                    bird2.ToSwim();
                }
                if (bird2.IFly)
                {
                    bird2.ToFly();
                }

            }
            catch
            {
                Console.WriteLine(new FormatException("Ошибка! У птицы пустое имя!"));
            }

        }
    }
}
