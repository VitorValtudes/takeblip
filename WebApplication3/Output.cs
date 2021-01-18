using System;

namespace WebApplication3
{
    public class Output
    {
        public string FullName { get; set; }
        public string Description { get; set; }

        public Output(string fullName, string description)
        {
            FullName = fullName;
            Description = description;
        }
    }
}
