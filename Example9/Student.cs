using System;

namespace Example9
{
    class Student : Person
    {
        public int Score { get; private set; }

        public void Read(int hours)
        {
            Score += hours * 5;
        }

        public void Write(int hours)
        {
            Score += hours * 10;
        }
    }
}
