using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSchool.Classes
{
    class GradeTheme
    {
        public int GthId { get; protected set; }
        public string GthName { get; protected set; }
        public int Gth_DepCSTid { get; protected set; }
        public int? GthRetake_GthId { get; protected set; }
        public DepClaSubTea GthDepClaSubTea { get; protected set; }

        public GradeTheme(string gthName, int gth_DepCSTid)
        {
            bool isDataCorrect = true;
            if (!(gthName.Length >= 1 & gthName.Length <= 20))
            {
                Console.WriteLine("Grade name has to contain from one to twenty letters or numbers");
            }
            else
            {
                foreach(char c in gthName)
                {
                    if (!((c >= 'a' & c <= 'z') | (c >= 'A' & c <= 'Z') | (c >= '0' & c <= '9')))
                    {
                        isDataCorrect = false;
                        Console.WriteLine("Grade name has to contain from one to twenty letters or numbers");
                        break;
                    }
                }
            }
            if (isDataCorrect)
            {
                GthName = gthName;
                Gth_DepCSTid = gth_DepCSTid;
            }
        }
        public GradeTheme(string gthName, int gth_DepCSTid, int retakeId) 
            :this (gthName, gth_DepCSTid)
        {
            GthRetake_GthId = retakeId;
        }
        public GradeTheme(int gthId, string gthName, int gth_DepCSTid) 
            :this(gthName, gth_DepCSTid)
        {
            GthId = gthId;
        }
        public GradeTheme(int gthId, string gthName, int gth_DepCSTid, int? gthRetakeId, DepClaSubTea gthDepClaSubTea)
            : this(gthId, gthName, gth_DepCSTid)
        {
            GthRetake_GthId = gthRetakeId;
            GthDepClaSubTea = gthDepClaSubTea;
        }
        public GradeTheme(int gthId)
        {
            GthId = gthId;
        }
        public GradeTheme() { }
        public GradeTheme(string gradeName)
        {
            GthName = gradeName;
        }
        public GradeTheme(string gradeName, DepClaSubTea depClaSubTea)
        {
            GthName = gradeName;
            GthDepClaSubTea = depClaSubTea;
        }
        public GradeTheme(string gradeName, int gthRetake_GthId, DepClaSubTea depClaSubTea)
        {
            GthName = gradeName;
            GthDepClaSubTea = depClaSubTea;
            GthRetake_GthId = gthRetake_GthId;
        }
        public GradeTheme(int gthId, string gthName)
        {
            GthId = gthId;
            GthName = gthName;
        }

        public bool Contains(List<GradeTheme> objs)
        {
            foreach (GradeTheme obj in objs) if (GthName == obj.GthName & Gth_DepCSTid == obj.Gth_DepCSTid) return true;
            return false;
        }
        public string gradeThemeInfo()
        {
            return $"({GthId}) Name: {GthName} CSTid: {Gth_DepCSTid} Retake?: '{GthRetake_GthId}'";
        }
    }
}
