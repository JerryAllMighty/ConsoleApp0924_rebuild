using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0924_rebuild
{
    class PhonenameComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            PhoneInfo first = x as PhoneInfo;
            PhoneInfo second = y as PhoneInfo;

            if (first.Name.CompareTo(second.Name) == 1) return 1;
            else if (first.Name.CompareTo(second.Name) == -1) return -1;
            else return 0;
        }
    }

    
    class PhoneInfo
    {
        string name;   //필수
        string phoneNumber;  //필수
        string birth;  //선택

        public string Name
        {
            get { return name; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
        }


        public PhoneInfo(string name, string phoneNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.birth = null;
        }

        public PhoneInfo(string name, string phoneNumber, string birth)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.birth = birth;
        }

        public void ShowPhoneInfo()
        {
            Console.Write("name: " + this.name);
            Console.Write("\t phone: " + this.phoneNumber);
            if (birth != null)
                Console.Write("\t birth: " + this.birth);
            Console.WriteLine();
        }

        public override string ToString()
        {
            return "name: " + this.name + "\n phone: " + this.phoneNumber + "\n birth: " + this.birth;
        }

        //public int CompareTo(object obj)
        //{
        //    PhoneInfo phone = obj as PhoneInfo;
        //    if (phone == null) return 0;

        //    if (this.name > phone) return 1;
        //}
    }
}
