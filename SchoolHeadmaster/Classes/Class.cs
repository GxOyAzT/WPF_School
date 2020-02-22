using System;
using System.Collections.Generic;

namespace ConsoleSchool.Classes
{
    public class Class
    {
        public int ClaId { get; protected set; }
        public string ClaName { get; protected set; }

        public Class(int claId, string claName)
        {
            ClaId = claId;
            ClaName = claName;
        }
        public Class(string claName)
        {
            if (claName.Length == 2)
            {
                if (claName[0] >= 49 & claName[0] <= 57 & claName[1] >= 65 & claName[1] <= 90) 
                    ClaName = claName;
                else
                {
                    Console.WriteLine("Class name first digit has to be a number from 1 to 9\n" +
                        "and second has to be capital letter.");
                }
            }
            else
            {
                Console.WriteLine("Class name first digit has to be a number from 1 to 9\n" +
                    "and second has to be capital letter.");
            }
        }

        public string classInfo()
        {
            return String.Format("|{0,3}|{1,5}|", ClaId, ClaName);
        }
        public bool Contains(List<Class> objs)
        {
            foreach(Class cla in objs) if (cla.ClaName == ClaName) return true;
            return false;
        }
    }
}
