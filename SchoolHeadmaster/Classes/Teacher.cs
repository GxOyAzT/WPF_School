using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSchool.Classes
{
    public class Teacher : Person
    {
        public int TeaId { get; protected set; }
        public bool TeaAdminPremission { get; protected set; } = false;
        public string TeaAdminPremissionToTable
        {
            get
            {
                if (TeaAdminPremission) return "YES";
                else return "NO";
            }
        }

        public Teacher(string perFirstName, string perLastName, 
            string perPesel, string perAdress, bool teaAdmPre) : 
            base(perFirstName, perLastName, perPesel, perAdress)
        {
            TeaAdminPremission = teaAdmPre;
        }
        public Teacher(int perId, int teaId ,string perFirstName, string perLastName, bool teaAdmPre)
        :base(perId, perFirstName, perLastName)
        {
            TeaId = teaId;
            TeaAdminPremission = teaAdmPre;
        }
        public Teacher() { }

        public string teacherInfo()
        {
            return String.Format("|{0,3}|{1,30}|{2,5}|", TeaId, PerFullName, TeaAdminPremission.ToString());
        }
        public bool Equals(List<Teacher> teas)
        {
            foreach (Teacher tea in teas)
                if (tea.PerFirstName == PerFirstName & tea.PerLastName == PerLastName)
                    return true;
            return false;
        }
    }
}
