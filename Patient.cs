using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class Patient
    {
        public string Name { get; set; }
        public string NationalID { get; set; }
        public string Phone { get; set; }

        public Patient(string name, string nationalId, string phone)
        {
            Name = name;
            NationalID = nationalId;
            Phone = phone;
        }
    }
}
