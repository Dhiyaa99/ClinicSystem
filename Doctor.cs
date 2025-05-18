using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class Doctor
    {
        
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Phone { get; set; }

        public Doctor(string name, string specialty, string phone)
        {
            Name = name;
            Specialty = specialty;
            Phone = phone;
        }
    }
}
