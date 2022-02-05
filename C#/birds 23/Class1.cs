using System;
using System.Collections.Generic;
using System.Text;

namespace Birds
{
    abstract class Bird : Fly, Swim
    {
        public string Name {get; set;}
        public bool ISwim { get; set; }
        public bool IFly { get; set; }

        public void WriteName()
        {
            Console.WriteLine(Name);
        }

        public abstract void ToFly();
        public abstract void ToSwim();
    }
    class Duck : Bird
    {
        public Duck(string name)
        {
            
            Name = name;
            if (Name.Length == 0)
            {
                throw new FormatException("Имя утки пустое");
            }
            ISwim = true;
            IFly = true;
        }

        public override void ToFly()
        {
            Console.Write("Утка ");
            Console.Write(Name);
            Console.WriteLine(" взлетела");
        }

        public override void ToSwim()
        {

            Console.Write("Утка ");
            Console.Write(Name);
            Console.WriteLine(" поплыла");
        }

    }
    class Penguin : Bird
    {

        public Penguin(string name)
        {
            
            Name = name;
            if (Name.Length == 0)
            {
                throw new FormatException("Имя пингвина пустое");
            }
            ISwim = true;
            IFly = false;
        }
        public override void ToFly()
        {
            Console.Write("Пингвин ");
            Console.Write(Name);
            Console.WriteLine(" не взлетел... Он не умеет летать");
        }
        public override void ToSwim()
        {
            

            Console.Write("Пингвин ");
            Console.Write(Name);
            Console.WriteLine(" поплыл");
        }
    }

    class Kiwi : Bird
    {

        public Kiwi(string name)
        {  
            Name = name;
            if (Name.Length == 0)
            {
                throw new FormatException("Имя киви пустое");
            }
            ISwim = false;
            IFly = false;
        }

        public override void ToFly()
        {
            Console.Write("Киви ");
            Console.Write(Name);
            Console.WriteLine(" не взлетел... Он не умеет летать");
        }

        public override void ToSwim()
        {
            Console.Write("Киви ");
            Console.Write(Name);
            Console.WriteLine(" не поплыл... Он не умеет плавать");
        }
    }
        class Budgie : Bird
        {

            public Budgie(string name)
            {
                
                Name = name;
                if (Name.Length == 0)
                {
                    throw new FormatException("Имя попугая пустое");
                }
                ISwim = false;
                IFly = true;
            }
            public override void ToFly()
            {
                Console.Write("Попугайчик ");
                Console.Write(Name);
                Console.WriteLine(" взлетел");
            }

            public override void ToSwim()
            {
                Console.Write("Попугайчик ");
                Console.Write(Name);
                Console.WriteLine(" не поплыл... Он не умеет плавать");
            }
        }
    
}

