using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSchool.Classes
{
    public class Subject
    {
        public int SubId { get; private set; }
        public string SubName { get; private set; }

        public Subject(string subName)
        {
            bool isDataCorrect = true;
            if (!(subName.Length >= 2 & subName.Length <= 20))
            {
                Console.WriteLine("Subject has to contain from two to twenty digits.");
                isDataCorrect = false;
            }
            else
            {
                if (!(subName[0] >= 65 & subName[0] <= 90))
                {
                    isDataCorrect = false;
                    Console.WriteLine("Subject has to start with capital digit.");
                }
                foreach (char c in subName.Remove(0,1))
                {
                    if (!(c >= 97 & c <= 122))
                    {
                        Console.WriteLine("Subject name can contain only letters.");
                        isDataCorrect = false;
                        break;
                    }
                }
            }
            if(isDataCorrect)
            {
                SubName = subName;
            }
        }
        public Subject(int subId, string subName) 
            :this(subName)
        {
            SubId = subId;
        }
        public Subject()
        {

        }

        public string subjectInfo()
        {
            return String.Format("|{0,3}|{1,20}|", SubId, SubName);
        }
        public bool Contains(List<Subject> subs)
        {
            foreach (Subject sub in subs) if (sub.SubName == SubName) return true;
            return false;
        }
    }
}
