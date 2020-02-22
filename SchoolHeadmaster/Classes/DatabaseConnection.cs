using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleSchool.Classes
{
    class DatabaseConnection
    {
        public List<Teacher> getAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            string sqlCommandGetAllTeachersInfo = "SELECT * FROM Teachers " +
                "INNER JOIN Persons ON Persons.PerId = Teachers.Tea_PerId";
            SqlCommand comGetAllTeachersInfo = new SqlCommand(sqlCommandGetAllTeachersInfo, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = comGetAllTeachersInfo.ExecuteReader();
                while(reader.Read())
                {
                    if (Convert.ToBoolean(Convert.ToInt32(reader["TeaAdmPrem"])))
                    {
                        teachers.Add(new Teacher(Convert.ToInt32(reader["PerId"]),
                        Convert.ToInt32(reader["TeaId"]),
                        reader["PerFirstName"].ToString(),
                        reader["PerLastName"].ToString(),
                        true
                        ));
                    }
                    else
                    {
                        teachers.Add(new Teacher(Convert.ToInt32(reader["PerId"]),
                        Convert.ToInt32(reader["TeaId"]),
                        reader["PerFirstName"].ToString(),
                        reader["PerLastName"].ToString(),
                        false
                        ));
                    }
                    
                }
            }
            catch(SqlException)
            {
                Console.WriteLine("DATABASE ERROR 1");
            }
            finally
            {
                connection.Close();
            }
            return teachers;
        }
        public List<Student> getAllStudents()
        {
            List<Student> students = new List<Student>();
            string sqlGetAllStudentInfo = "SELECT * FROM Students " +
                "INNER JOIN Persons ON Persons.PerId = Students.Stu_PerId " +
                "INNER JOIN Classes ON Classes.ClaId = Students.Stu_ClaId";
            SqlCommand comGetAllStudentsInfo = new SqlCommand(sqlGetAllStudentInfo, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = comGetAllStudentsInfo.ExecuteReader();
                while(reader.Read())
                {
                    students.Add(new Student(
                        Convert.ToInt32(reader["StuId"]),
                        Convert.ToInt32(reader["PerId"]),
                        reader["PerFirstName"].ToString(),
                        reader["PerLastName"].ToString(),
                        new Class(
                            Convert.ToInt32(reader["ClaId"]),
                            reader["ClaName"].ToString())));
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("DATABASE ERROR 2");
            }
            finally
            {
                connection.Close();
            }
            return students;
        }
        public List<Class> getAllClasses()
        {
            List<Class> classes = new List<Class>();
            string sqlGetAllClassesInfo = "SELECT * FROM Classes";
            SqlCommand conGetAllClassesInfo = new SqlCommand(sqlGetAllClassesInfo, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = conGetAllClassesInfo.ExecuteReader();
                while(reader.Read())
                {
                    classes.Add(new Class(
                        Convert.ToInt32(reader["ClaId"]),
                        reader["ClaName"].ToString()
                        ));
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("DATABASE ERROR 3");
            }
            finally
            {
                connection.Close();
            }
            return classes;
        }
        public List<Subject> getAllSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            string sqlGetAllSubjects = $"SELECT * FROM Subjects";
            SqlCommand conGetAllSubjects = new SqlCommand(sqlGetAllSubjects, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = conGetAllSubjects.ExecuteReader();
                while(reader.Read())
                {
                    subjects.Add(new Subject(
                        Convert.ToInt32(reader["SubId"]),
                        reader["SubName"].ToString()));
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("DATABASE ERROR 7");
            }
            finally
            {
                connection.Close();
            }
            return subjects;
        }
        public List<DepClaSubTea> getAllDepClaSubTeas()
        {
            List<DepClaSubTea> depClaSubTeas = new List<DepClaSubTea>();
            string sqlGetAllDepClaSubTea = $"SELECT * FROM DepClaSubTea";
            SqlCommand comGetAllDepClaSubTea = new SqlCommand(sqlGetAllDepClaSubTea, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = comGetAllDepClaSubTea.ExecuteReader();
                while(reader.Read())
                {
                    depClaSubTeas.Add(new DepClaSubTea(
                        Convert.ToInt32(reader["DepCST"]),
                        Convert.ToInt32(reader["_ClaId"]),
                        Convert.ToInt32(reader["_SubId"]),
                        Convert.ToInt32(reader["_TeaId"])));
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("DATABASE ERROR 9");
            }
            finally
            {
                connection.Close();
            }
            return depClaSubTeas;
        }
        public List<GradeTheme> getAllGradeThemes()
        {
            List<GradeTheme> gradeThemes = new List<GradeTheme>();
            string sqlGetAllGradeThemes = "SELECT * FROM GradeThemes";
            SqlCommand comGetAllGradeThemes = new SqlCommand(sqlGetAllGradeThemes, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = comGetAllGradeThemes.ExecuteReader();
                while(reader.Read())
                {
                    if (reader["GthRetake_GthId"].ToString() == "")
                    {
                        gradeThemes.Add(new GradeTheme(
                            Convert.ToInt32(reader["GthId"]),
                            reader["GthName"].ToString(),
                            Convert.ToInt32(reader["Gth_DepCSTid"]),
                            null,
                            new DepClaSubTea(
                                Convert.ToInt32(reader["Gth_ClaId"]),
                                Convert.ToInt32(reader["Gth_SubId"]),
                                Convert.ToInt32(reader["Gth_TeaId"]))));
                    }
                    else
                    {
                        gradeThemes.Add(new GradeTheme(
                            Convert.ToInt32(reader["GthId"]),
                            reader["GthName"].ToString(),
                            Convert.ToInt32(reader["Gth_DepCSTid"]),
                            Convert.ToInt32(reader["GthRetake_GthId"]),
                            new DepClaSubTea(
                                Convert.ToInt32(reader["Gth_ClaId"]),
                                Convert.ToInt32(reader["Gth_SubId"]),
                                Convert.ToInt32(reader["Gth_TeaId"]))));
                    }
                }
            }
            catch(SqlException)
            {
                Console.WriteLine("DATABASE getAllGradeThemes ERROR");
            }
            finally
            {
                connection.Close();
            }
            return gradeThemes;
        }
        public List<Grade> getAllGrades()
        {
            List<Grade> grades = new List<Grade>();
            string slqGetAllGrades = "SELECT * FROM Grades";
            SqlCommand comGetAllGrades = new SqlCommand(slqGetAllGrades, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = comGetAllGrades.ExecuteReader();
                while(reader.Read())
                {
                    grades.Add(new Grade(
                        Convert.ToInt32(reader["GraId"]),
                        Convert.ToInt32(reader["Gra_StuId"]),
                        Convert.ToInt32(reader["GraMark"]),
                        Convert.ToInt32(reader["Gra_GthId"])));
                }
            }
            catch(SqlException)
            {
                Console.WriteLine("DATABASE getAllGrades ERROR");
            }
            finally
            {
                connection.Close();
            }
            return grades;
        }
        public List<Grade> getFullGradesInfoFilteredDepClaSubTea(int depClaSubTeaId)
        {
            List<Grade> grades = new List<Grade>();
            string sqlGetFullGradesInfoFilteredDepClaSubTea = $"SELECT GradeThemes.GthId, Grades.Gra_StuId, Grades.GraMark, GradeThemes.GthName, GradeThemes.Gth_DepCSTid FROM Grades " +
                $"JOIN GradeThemes ON Grades.Gra_GthId = GradeThemes.GthId WHERE GradeThemes.Gth_DepCSTid = {depClaSubTeaId}";

            SqlCommand comGetFullGradesInfoFilteredDepClaSubTea = new SqlCommand(sqlGetFullGradesInfoFilteredDepClaSubTea, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = comGetFullGradesInfoFilteredDepClaSubTea.ExecuteReader();
                while (reader.Read())
                {
                    grades.Add(new Grade(
                        Convert.ToInt32(reader["Gra_StuId"]),
                        Convert.ToInt32(reader["GraMark"]),
                        reader["GthName"].ToString(),
                        Convert.ToInt32(reader["GthId"])));
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("DATABASE getAllGrades ERROR");
            }
            finally
            {
                connection.Close();
            }
            return grades;
        }
        public List<Grade> getFullGradesInfoFilteredSubIdStuId(int subId, int stuId)
        {
            List<Grade> grades = new List<Grade>();
            string sql = $"SELECT * FROM Grades INNER JOIN GradeThemes ON Grades.Gra_GthId = GradeThemes.GthId " +
                $"WHERE Gth_SubId = {subId} and Gra_StuId = {stuId}";
            SqlCommand com = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    grades.Add(new Grade(
                        -1,
                        Convert.ToInt32(reader["GraMark"]),
                        reader["GthName"].ToString(),
                        -1));
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("DATABASE getAllGrades ERROR");
            }
            finally
            {
                connection.Close();
            }
            return grades;
        }
        public List<DepSubTea> getAllDepSubTeas()
        {
            List<DepSubTea> depSubTeas = new List<DepSubTea>();
            string sqlgetAllDepSubTeas = "SELECT * FROM DepSubTea";
            SqlCommand comgetAllDepSubTeas = new SqlCommand(sqlgetAllDepSubTeas, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = comgetAllDepSubTeas.ExecuteReader();
                while (reader.Read())
                {
                    depSubTeas.Add(new DepSubTea(
                        Convert.ToInt32(reader["_SubId"]),
                        Convert.ToInt32(reader["_TeaId"])));
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("DATABASE getAllDepSubTeas ERROR");
            }
            finally
            {
                connection.Close();
            }
            return depSubTeas;
        }
        public Account SearchByUsernamePassword(Account account)
        {
            Account accountResult = new Account();
            string sqlSearchByUsernamePassword = $"SELECT Acc_PerId FROM Accounts " +
                $"WHERE AccUsername = '{account.AccUsername}' and AccPassword = '{account.AccPassword}'";

            SqlCommand comSearchByUsernamePassword = new SqlCommand(sqlSearchByUsernamePassword, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = comSearchByUsernamePassword.ExecuteReader();
                while (reader.Read())
                {
                    accountResult = new Account(Convert.ToInt32(reader["Acc_PerId"]));
                }
            }
            catch(SqlException)
            {
                Console.WriteLine("DATABASE SearchByUsernamePassword ERROR");
            }
            finally
            {
                connection.Close();
            }
            return accountResult;
        }
        public bool createNewTeacher(Teacher teacher)
        {
            if (!(correction.checkTeacherData(teacher, getAllTeachers())))
            { Console.WriteLine("Database: can't add empty 'teacher' object."); return false; }

            string sqlCreateNewTeacher;
            if (teacher.TeaAdminPremission == true)
            {
                sqlCreateNewTeacher = $"INSERT INTO Persons " +
                    $"(PerFirstName, PerLastName, PerPesel, PerAdress) " +
                    $"VALUES ('{teacher.PerFirstName}', '{teacher.PerLastName}', " +
                    $"'{teacher.PerPesel}', '{teacher.PerAdress}') " +
                    $"INSERT INTO Teachers (Tea_PerId, TeaAdmPrem) " +
                    $"VALUES ((SELECT PerId FROM Persons WHERE PerFirstName = '{teacher.PerFirstName}' " +
                    $"and PerLastName = '{teacher.PerLastName}'), '1')";
            }
            else
            {
                sqlCreateNewTeacher = $"INSERT INTO Persons " +
                    $"(PerFirstName, PerLastName, PerPesel, PerAdress) " +
                    $"VALUES ('{teacher.PerFirstName}', '{teacher.PerLastName}', " +
                    $"'{teacher.PerPesel}', '{teacher.PerAdress}') " +
                    $"INSERT INTO Teachers (Tea_PerId, TeaAdmPrem) " +
                    $"VALUES ((SELECT PerId FROM Persons WHERE PerFirstName = '{teacher.PerFirstName}' " +
                    $"and PerLastName = '{teacher.PerLastName}'), '0')";
            }
            
            SqlCommand comCreateNewTeacher = new SqlCommand(sqlCreateNewTeacher, connection);
            try
            {
                connection.Open();
                comCreateNewTeacher.ExecuteNonQuery();
            }
            catch(SqlException)
            {
                Console.WriteLine("DATABASE ERROR 4");
            }
            finally
            {
                connection.Close();
            }
            createNewAccount(teacher.PerFirstName, teacher.PerLastName);
            return true;
        }
        public bool createNewStudent(Student student)
        {
            if (!(correction.checkStudentData(student, getAllStudents()))) 
            { Console.WriteLine("Database: can't add empty 'student' object."); return false; }

            string sqlCreateNewStudent = $"INSERT INTO Persons " +
                $"(PerFirstName, PerLastName, PerPesel, PerAdress) " +
                $"VALUES ('{student.PerFirstName}', '{student.PerLastName}', " +
                $"'{student.PerPesel}', '{student.PerAdress}') " +
                $"INSERT INTO Students (Stu_PerId, Stu_ClaId) " +
                $"VALUES ((SELECT PerId FROM Persons " +
                $"WHERE PerFirstName = '{student.PerFirstName}' and " +
                $"PerLastName = '{student.PerLastName}'), {student.StuClass.ClaId})";
            SqlCommand comCreateNewStudent = new SqlCommand(sqlCreateNewStudent, connection);
            try
            {
                connection.Open();
                comCreateNewStudent.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                Console.WriteLine("DATABASE createNewStudent ERROR");
            }
            finally
            {
                connection.Close();
            }
            createNewAccount(student.PerFirstName, student.PerLastName);
            return true;
        }
        public bool createNewAccount(string firstName, string lastName)
        {
            int perId = -1;
            string sqlGetPerson = $"SELECT PerId FROM Persons " +
                $"WHERE PerFirstName = '{firstName}' AND PerLastName = '{lastName}'";
            SqlCommand comGetPer = new SqlCommand(sqlGetPerson, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = comGetPer.ExecuteReader();
                while(reader.Read())
                {
                    perId = Convert.ToInt32(reader["PerId"]);
                }
                connection.Close();
                connection.Open();
                string sqlCreate = "INSERT INTO Accounts (Acc_PerId, AccUsername, AccPassword)" +
                    $"VALUES ({perId}, '{firstName}{lastName}', 'Password')";
                SqlCommand com = new SqlCommand(sqlCreate, connection);
                com.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                Console.WriteLine("DATABASE createNewAccount ERROR");
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public bool createNewClass(Class _class)
        {
            if (!(correction.checkClassData(_class, getAllClasses())))
            { Console.WriteLine("This class exists in database or format is incorrect."); return false; }

            string sqlCreateNewClass = $"INSERT INTO Classes (ClaName) VALUES ('{_class.ClaName}')";
            SqlCommand comCreateNewClass = new SqlCommand(sqlCreateNewClass, connection);
            try
            {
                connection.Open();
                comCreateNewClass.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                Console.WriteLine("DATABASE ERROR 6");
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public bool createNewSubject(Subject subject)
        {
            if (!(correction.checkSubjectData(subject, getAllSubjects())))
            { Console.WriteLine("This subject exists in database or format is incorrect."); return false; }

            string sqlCreateNewSubject = $"INSERT INTO Subjects (SubName) VALUES ('{subject.SubName}')";
            SqlCommand comCreateNewSubject = new SqlCommand(sqlCreateNewSubject, connection);
            try
            {
                connection.Open();
                comCreateNewSubject.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                Console.WriteLine("DATABASE ERROR 6");
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public bool createDependenceClassSubjectTeacher(DepClaSubTea depClaSubTea)
        {
            if (!(correction.checkDepClaSubTea(depClaSubTea, getAllDepClaSubTeas())))
            { Console.WriteLine("This dependence exists in database."); return false; }

            string sqlCreateDepClaSubTea = $"INSERT INTO DepClaSubTea (_ClaId, _SubId, _TeaId) " +
                $"VALUES ({depClaSubTea._ClaId},{depClaSubTea._SubId},{depClaSubTea._TeaId})";
            SqlCommand comCreateDepClaSubTea = new SqlCommand(sqlCreateDepClaSubTea, connection);
            try
            {
                connection.Open();
                comCreateDepClaSubTea.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                Console.WriteLine("DATABASE ERROR 8");
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public bool createNewGradeTheme(GradeTheme gradeTheme)
        {
            if (!(correction.checkGradeThemeData(gradeTheme, getAllGradeThemes())))
            { Console.WriteLine("Grade's theme is incorrect or exists in database."); return false; }

            string sqlCreateNewGradeTheme;
            if (gradeTheme.GthRetake_GthId == null)
            {
                sqlCreateNewGradeTheme = $"INSERT INTO GradeThemes " +
                    $"(GthName, Gth_SubId, Gth_TeaId, Gth_ClaId, Gth_DepCSTid) " +
                    $"VALUES ('{gradeTheme.GthName}',{gradeTheme.GthDepClaSubTea._SubId},{gradeTheme.GthDepClaSubTea._TeaId}, " +
                    $"{gradeTheme.GthDepClaSubTea._ClaId}, {gradeTheme.GthDepClaSubTea.DepCSTid})";
            }
            else
            {
                sqlCreateNewGradeTheme = $"INSERT INTO GradeThemes " +
                    $"(GthName, Gth_SubId, Gth_TeaId, Gth_ClaId, GthRetake_GthId, Gth_DepCSTid) " +
                    $"VALUES ('{gradeTheme.GthName}',{gradeTheme.GthDepClaSubTea._SubId},{gradeTheme.GthDepClaSubTea._TeaId}, " +
                    $"{gradeTheme.GthDepClaSubTea._ClaId}, {gradeTheme.GthRetake_GthId}, {gradeTheme.GthDepClaSubTea.DepCSTid})";
            }
            SqlCommand comCreateNewGradeTheme = new SqlCommand(sqlCreateNewGradeTheme, connection);
            try
            {
                connection.Open();
                comCreateNewGradeTheme.ExecuteNonQuery();
            }
            catch(SqlException)
            {
                Console.WriteLine("DATABASE createnewgradetheme ERROR");
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public void createNewGrade(Grade grade)
        {
            if (!(correction.checkGradeData(grade, getAllGrades())))
            { Console.WriteLine("Grade exists in database"); return; }

            string sqlCreateNewGrade = "INSERT INTO Grades (Gra_GthId, Gra_StuId, GraMark) " +
                $"VALUES ({grade.GthId},{grade.Gra_StuId},{grade.GraMark})";
            SqlCommand comCreateNewGrade = new SqlCommand(sqlCreateNewGrade, connection);
            try
            {
                connection.Open();
                comCreateNewGrade.ExecuteNonQuery();
            }
            catch(SqlException)
            {
                Console.WriteLine("DATABASE createNewGrade ERROR");
            }
            finally
            {
                connection.Close();
            }
        }
        public bool createNewDepSubTea(DepSubTea depSubTea)
        {
            if(!(correction.checkDepClaTea(depSubTea, getAllDepSubTeas())))
            { Console.WriteLine("Dependence exists in database."); return false; }

            string sqlCreateNewDepSubTea = "INSERT INTO DepSubTea (_SubId, _TeaId) " +
                $"VALUES ({depSubTea._SubId}, {depSubTea._TeaId})";
            SqlCommand comCreateNewDepSubTea = new SqlCommand(sqlCreateNewDepSubTea, connection);
            try
            {
                connection.Open();
                comCreateNewDepSubTea.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                Console.WriteLine("DATABASE createNewDepSubTea ERROR");
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public void changePassword(int perId, string newPassword)
        {
            string sql = $"UPDATE Accounts SET AccPassword = '{newPassword}' WHERE Acc_PerId = {perId}";
            SqlCommand com = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                com.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                Console.WriteLine("SQL changePassword ERROR");
            }
            finally
            {
                connection.Close();
            }
        }
        

        DataCorrectness correction = new DataCorrectness();
        SqlConnection connection = new SqlConnection("Server=localhost; Integrated security=SSPI; database=School");
    }
}