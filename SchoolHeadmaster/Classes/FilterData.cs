using ConsoleSchool.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Classes
{
    class FilterData
    {
        public List<DepClaSubTea> FilterDepClaSubTeaByTeaId(List<DepClaSubTea> depClaSubTeas, int _teaId)
        {
            List<DepClaSubTea> depClaSubTeasResult = new List<DepClaSubTea>();
            foreach (DepClaSubTea depClaSubTea in depClaSubTeas)
            {
                if (depClaSubTea._TeaId == _teaId) depClaSubTeasResult.Add(depClaSubTea);
            }
            return depClaSubTeasResult;
        }
        public List<DepClaSubTea> FilterDepClaSubTeaByClaId(List<DepClaSubTea> depClaSubTeas, int _claId)
        {
            List<DepClaSubTea> depClaSubTeasResult = new List<DepClaSubTea>();
            foreach (DepClaSubTea depClaSubTea in depClaSubTeas)
            {
                if (depClaSubTea._ClaId == _claId) depClaSubTeasResult.Add(depClaSubTea);
            }
            return depClaSubTeasResult;
        }
        public List<Class> FilterClassesByClassId(List<Class> classes, List<DepClaSubTea> depClaSubTeas)
        {
            List<Class> classesResult = new List<Class>();

            foreach(DepClaSubTea depClaSubTea in depClaSubTeas)
                foreach(Class clas in classes)
                    if (depClaSubTea._ClaId == clas.ClaId) classesResult.Add(clas);

            return classesResult;
        }
    }
}
