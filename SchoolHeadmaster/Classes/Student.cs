using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSchool.Classes
{
    public class Student : Person
    {
        public int StuId { get; protected set; }
        public Class StuClass { get; protected set; }
        public string Stu_ClaName
        {
            get
            {
                return StuClass.ClaName;
            }
        }

        //public List<Grade> StuGrades = new List<Grade>();

        public Student(int stuId, int perId, string perFirstName, string perLastName, Class stuClass)
            :base(perId, perFirstName, perLastName)
        {
            StuId = stuId;
            StuClass = stuClass;
        }
        public Student(string perFirstName, string perLastName, 
            string perPesel, string perAdress, Class stuClass)
            :base(perFirstName, perLastName, perPesel, perAdress)
        {
            StuClass = stuClass;
        }
        public Student()
        {

        }

        public string studentInfo()
        {
            return String.Format("|{0,3}|{1,30}|", StuId, PerFullName);
        }
        public bool Contains(List<Student> stus)
        {
            foreach (Student stu in stus)
                if (stu.PerFirstName == PerFirstName & stu.PerLastName == PerLastName)
                    return true;
            return false;
        }
        //public void AddNewGrade (Grade newGrade)
        //{
        //    StuGrades.Add(newGrade);
        //}
    }
}
