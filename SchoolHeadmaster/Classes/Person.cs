using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSchool.Classes
{
    public abstract class Person
    {
        public int PerId { get; protected set; }
        public string PerFirstName { get; protected set; }
        public string PerLastName { get; protected set; }
        public string PerFullName { get { return $"{PerFirstName} {PerLastName}"; } }
        public string PerUsername { get { return $"{PerFirstName}{PerLastName}"; } }
        public string PerPesel { get; protected set; }
        public string PerAdress { get; protected set; }

        protected Person(string perFirstName, string perLastName, 
            string perPesel, string perAdress)
        {
            bool isDataCorrect = true;
            if (!(perFirstName.Length >= 2 & perFirstName.Length <= 20))
            {
                Console.WriteLine("First name has to contain from two to twenty digits.");
                isDataCorrect = false;
            }
            else
            {
                if (!(perFirstName[0] >= 65 & perFirstName[0] <= 90))
                {
                    Console.WriteLine("First name has to start with capital leter.");
                    isDataCorrect = false;
                }
                foreach (char c in perFirstName.Remove(0, 1))
                {
                    if (!(c >= 97 & c <= 122))
                    {
                        Console.WriteLine("First name can contain only letters.");
                        isDataCorrect = false;
                        break;
                    }
                }
            }
            if (!(perFirstName.Length >= 2 & perFirstName.Length <= 20))
            {
                Console.WriteLine("Last name has to contain from two to twenty digits.");
                isDataCorrect = false;
            }
            else
            {
                if (!(perLastName[0] >= 65 & perLastName[0] <= 90))
                {
                    Console.WriteLine("Last name has to start with capital leter!");
                    isDataCorrect = false;
                }
                foreach (char c in perLastName.Remove(0, 1))
                {
                    if (!(c >= 97 & c <= 122))
                    {
                        Console.WriteLine("Last name can contain only letters.");
                        isDataCorrect = false;
                        break;
                    }
                }
            }
            if (!(perPesel.Length == 11))
            {
                Console.WriteLine("Pesel has to contain eleven numbers.");
                isDataCorrect = false;
                foreach (char c in perPesel)
                {
                    if (!(c >= 48 & c <= 57))
                    {
                        Console.WriteLine("Pesel can contain only numbers.");
                        isDataCorrect = false;
                        break;
                    }
                }
            }
            if (!(perAdress.Length <= 50))
            {
                Console.WriteLine($"Adress can contain only fivety characters. Now it's {perAdress.Length}");
                isDataCorrect = false;
            }
            if (isDataCorrect)
            {
                PerFirstName = perFirstName;
                PerLastName = perLastName;
                PerPesel = perPesel;
                PerAdress = perAdress;
            }
        }
        protected Person(int perId, string perFirstName, string perLastName)
        {
            PerId = perId;
            PerFirstName = perFirstName;
            PerLastName = perLastName;
        }
        protected Person() { }
    }
}
