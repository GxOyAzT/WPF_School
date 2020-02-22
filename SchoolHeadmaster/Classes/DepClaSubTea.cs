using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSchool.Classes
{
    public class DepClaSubTea
    {
        public int DepCSTid { get; private set; }
        public int _ClaId { get; private set; }
        public int _SubId { get; private set; }
        public int _TeaId { get; private set; }
        public string ClaName
        {
            get
            {
                Class classResult = db.getAllClasses().Find(
                    delegate (Class clas)
                    {
                        return clas.ClaId == _ClaId;
                    });
                return classResult.ClaName;
            }
        }
        public string SubName
        {
            get
            {
                Subject subjectResult = db.getAllSubjects().Find(
                    delegate (Subject subj)
                    {
                        return subj.SubId == _SubId;
                    });
                return subjectResult.SubName;
            }
        }
        public string TeaName
        {
            get
            {
                Teacher teacherResult = db.getAllTeachers().Find(
                    delegate (Teacher teach)
                    {
                        return teach.TeaId == _TeaId;
                    });
                return teacherResult.PerFullName;
            }
        }
        public string ClaSubName
        {
            get
            {
                return $"{ClaName} - {SubName}";
            }
        }
        public DepClaSubTea(int cla, int sub, int tea)
        {
            _ClaId = cla;
            _SubId = sub;
            _TeaId = tea;
        }
        public DepClaSubTea(int depCSTid, int cla, int sub, int tea)
            :this (cla, sub, tea)
        {
            DepCSTid = depCSTid;
        }
        public DepClaSubTea() { }
        public string depClaSubTeaInfo()
        {
            return $"Class - {_ClaId}, Subject - {_SubId}, Teacher - {_TeaId},";
        }
        public bool Contains(List<DepClaSubTea> objs)
        {
            foreach(DepClaSubTea depClaSubTea in objs) 
                if (_ClaId == depClaSubTea._ClaId & 
                    _SubId == depClaSubTea._SubId & 
                    _TeaId == depClaSubTea._TeaId) 
                    return true;
            return false;
        }

        DatabaseConnection db = new DatabaseConnection();
    }
}
