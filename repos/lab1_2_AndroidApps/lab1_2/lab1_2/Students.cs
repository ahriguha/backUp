using System;
using System.Collections.Generic;
using System.Text;

namespace lab1_2
{
    class Students
    {
        private string name;
        private string groupNumber;

        public Students(string name, string groupNumber)
        {
            this.name = name;
            this.groupNumber = groupNumber;
        }

        public string GetName()
        {
            return name;
        }

        public string GetGroupNumber()
        {
            return groupNumber;
        }

        private static List<Students> students = new List<Students>
        {
            new Students("Saliutin", "301"),
            new Students("Belousova", "301"),
            new Students("Budanov", "301"),
            new Students("Balutin", "301"),
            new Students("Golets", "301"),
            new Students("Medvid", "302"),
            new Students("Muradyan", "302"),
            new Students("Gress", "302"),
            new Students("Sova", "302"),
            new Students("Kucherenko", "303"),
            new Students("Dimo", "303"),
            new Students("Belous", "303")
        };
        
        public static List<Students> getStudents(string groupNumber)
        {
            List<Students> resList = new List<Students>();
            foreach(Students s in students)
            {
                if (s.GetGroupNumber() == groupNumber)
                {
                    resList.Add(s);
                }
            }
            return resList;
        }
    }
}
