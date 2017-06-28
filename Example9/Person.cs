using System;

namespace Example9
{
    class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
