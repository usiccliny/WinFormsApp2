using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class Employee
    {
        public string fio { get; set; }
        public int age { get; set; }
        public int salary { get; set; }
        public string branch_address { get; set; }

        public Employee(string fio, int age, int salary, string branch_address)
        {
            this.fio = fio;
            this.age = age;
            this.salary = salary;
            this.branch_address = branch_address;
        }
    }
}
