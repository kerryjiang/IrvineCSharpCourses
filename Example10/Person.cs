using System;

namespace Example10
{
    class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        protected string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
