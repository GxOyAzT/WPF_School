using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSchool.Classes
{
    class DataCorrectness
    {
        public bool checkDepClaSubTea(DepClaSubTea newDepClaSubTea,
            List<DepClaSubTea> oldDepClaSubTeas)
        {
            if (newDepClaSubTea.Contains(oldDepClaSubTeas)) return false;
            else return true;
        }

        public bool checkClassData(Class newClass,
            List<Class> oldClasses)
        {
            if (newClass.Contains(oldClasses) | newClass.ClaName == null) return false;
            else return true;
        }

        public bool checkSubjectData(Subject newSubject,
            List<Subject> oldSubjects)
        {
            if (newSubject.Contains(oldSubjects) | newSubject.SubName == null) return false;
            else return true;
        }

        public bool checkTeacherData(Teacher newTeacher,
            List<Teacher> oldTeachers)
        {
            if (newTeacher.Equals(oldTeachers) | newTeacher.PerFirstName == null) return false;
            else return true;
        }

        public bool checkStudentData(Student newStudent,
            List<Student> oldStudents)
        {
            if (newStudent.Contains(oldStudents) | newStudent.PerFirstName == null |
                newStudent.StuClass == null) return false;
            else return true;
        }

        public bool checkGradeThemeData(GradeTheme newGradetheme,
            List<GradeTheme> oldGradeThemes)
        {
            if (newGradetheme.Contains(oldGradeThemes) | newGradetheme.GthName == null) return false;
            else return true;
        }

        public bool checkGradeData(Grade newGrade,
            List<Grade> oldGrade)
        {
            if (newGrade.Contains(oldGrade)) return false;
            else return true;
        }

        public bool checkDepClaTea(DepSubTea depSubTea,
            List<DepSubTea> depSubTeas)
        {
            if (depSubTea.Consists(depSubTeas) |
                depSubTea._SubId == null | depSubTea._TeaId == null) return false;
            else return true;
        }

        public bool chechIfGthExistsByName(GradeTheme newGradeTheme,
            List<GradeTheme> gradeThemes)
        {
            foreach (GradeTheme gradeTheme in gradeThemes) 
                if (gradeTheme.GthName == newGradeTheme.GthName) return true;
            return false;
        }

        public bool checkIfGradeThemeReferenceExists(GradeTheme newGradeTheme,
            List<GradeTheme> gradeThemes)
        {
            foreach (GradeTheme gradeTheme in gradeThemes) 
                if(gradeTheme.GthRetake_GthId == newGradeTheme.GthRetake_GthId & 
                    gradeTheme.GthRetake_GthId != null & newGradeTheme.GthRetake_GthId != null) return true;
            return false;
        }
    }
}
