using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Model
{
    public class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime DoB { get; set; }

        public string Email { get; set; }

        public string CurrentLevel { get; set; }


        public int DepartmentID { get; set; }
        public string Phone { get; set; }

        public string EmployeeCode { get; set; }

        public int StatusEmployee { get; set; }

        public int BasicSalary { get; set; }

        public int CoefficyTimeKeeping { get; set; }

        public float CoefficyPower { get; set; }

        public int TaxFee { get; set; }

        public int Insurance { get; set; }

        public int Advance { get; set; }

        public int Month { get; set; }

        public int StatusPaycheck { get; set; }

        public int PaymentStatus { get; set; }

    }
}
