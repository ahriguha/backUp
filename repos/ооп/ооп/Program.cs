using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_
{
    struct Sportsman
    {
        public string name;
        public string state;
        public int am_of_medals;
        public Sportsman(string name, string state, int am_of_medals)
        {
            this.name = name;
            this.state = state;
            this.am_of_medals = am_of_medals;
        }
        public void Display()
        {
            Console.WriteLine($"Name: {name} State: {state} Amount of medals: {am_of_medals}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}
