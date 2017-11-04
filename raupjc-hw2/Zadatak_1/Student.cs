using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; } //Jmbag mora biti readonly zbog GetHashCode();
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {
            if(obj != null)
            {
                Student s = (Student)obj;

                if (s.Name.Equals(Name) 
                    && s.Jmbag.Equals(Jmbag) 
                    && s.Gender.Equals(Gender))
                {
                    return true;
                }
            }
            return false;
        }
        public override int GetHashCode() => Jmbag.GetHashCode();
        public static bool operator ==(Student s1, Student s2)
        {
            Object obj1 = s1;
            Object obj2 = s2;

            if (obj1 != null) return s1.Equals(s2);
            if (obj2 == null) return true;

            return false;
        }
        public static bool operator !=(Student s1, Student s2)
        {
            Object obj1 = s1;
            Object obj2 = s2;

            if (obj1 != null) return !s1.Equals(s2);
            if (obj2 == null) return false;

            return true;
        }
    }
    public enum Gender
    {
        Male, Female
    }
}
