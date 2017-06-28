using System;

namespace Example10
{
    class Student : Person
    {
        private int score;

        public void Read(int hours)
        {
            score += hours * 5;
        }

        public void Write(int hours)
        {
            score += hours * 10;
        }

        public int GetScore()
        {
            return score;
        }

        public string GetStudentName()
        {
            return GetFullName();
        }
    }
}
