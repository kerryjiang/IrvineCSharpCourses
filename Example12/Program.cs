using System;
using System.Collections.Generic;

namespace Example12
{
    interface IFlyable
    {
        void Fly();
    }

    class Bird : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Bird fly");
        }
    }

    interface ICrashable
    {
        void Crash();
    }

    class Plane : IFlyable, ICrashable
    {
        public void Fly()
        {
            Console.WriteLine("Plane fly");
        }

        public void Crash()
        {
            Console.WriteLine("100 people died");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IFlyable> things = new List<IFlyable>();

            things.Add(new Bird());
            things.Add(new Plane());

            foreach(IFlyable item in things)
            {
                item.Fly();
            }
        }
    }
}
