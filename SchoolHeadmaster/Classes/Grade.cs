using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSchool.Classes
{
    class Grade : GradeTheme
    {
        public int GraId { get; protected set; }
        public int Gra_StuId { get; protected set; }
        public string Gra_StuFullName
        {
            get
            {
                foreach (Student student in db.getAllStudents()) if (student.StuId == Gra_StuId) return student.PerFullName;
                return "GRADE>GRA_StuFullName>ERROR";
            }
        }


        public int GraMark { get; protected set; }

        public Grade(int graStuId, int graMark, int gthId)
            :base(gthId)
        {
            Gra_StuId = graStuId;
            GraMark = graMark;
        }
        public Grade(int graId, int graStuId, int graMark, int gthId) 
            :base(gthId)
        {
            GraId = graId;
            Gra_StuId = graStuId;
            GraMark = graMark;
        }
        public Grade(int stuId, int graMark, string gthName, int gthId)
            :base(gthId, gthName)
        {
            Gra_StuId = stuId;
            GraMark = graMark;
        }

        public bool Contains(List<Grade> objs)
        {
            foreach (Grade obj in objs) 
                if (obj.Gra_StuId == Gra_StuId & obj.GthId == GthId) 
                    return true;
            return false;
        }
        public string gradeInfo()
        {
            return $"({GraId}) Sudent: {Gra_StuId} Mark: {GraMark}";
        }

        DatabaseConnection db = new DatabaseConnection();
    }
}
