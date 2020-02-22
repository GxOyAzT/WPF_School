using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSchool.Classes
{
    class DepSubTea
    {
        public int _SubId { get; protected set; }
        public int _TeaId { get; protected set; }
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

        public DepSubTea(int _subId, int _teaId)
        {
            _SubId = _subId;
            _TeaId = _teaId;
        }

        public bool Consists (List<DepSubTea> depSubTeas)
        {
            foreach (DepSubTea depSubTea in depSubTeas)
                if (depSubTea._SubId == _SubId & depSubTea._TeaId == _TeaId)
                    return true;
            return false;
        }

        DatabaseConnection db = new DatabaseConnection();
    }
}
