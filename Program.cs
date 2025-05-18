using System;
using System.Collections.Generic;
using System.Linq;
using ClinicSystem.Models;

namespace OmanClinicAppointmentSystem
{
    class Program
    {
        static List<Patient> patients = new List<Patient>();
        static List<Doctor> doctors = new List<Doctor>();
        static List<Appointment> appointments = new List<Appointment>();

        static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("--------------------------------------------------------------");


                Console.WriteLine("Welcome to Oman Clinic Appointment System");
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("--------------------------------------------------------------");


                Console.WriteLine("1. Register New Patient");
                Console.WriteLine("2. Add New Doctor");
                Console.WriteLine("3. Search Doctor by Specialty");
                Console.WriteLine("4. Book Appointment");
                Console.WriteLine("5. View Patient Appointments");
                Console.WriteLine("6. View All Appointments");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("--------------------------------------------------------------");


                switch (choice)
                {
                    case 1: RegisterPatient(); break;
                    case 2: AddDoctor(); break;
                    case 3: SearchDoctor(); break;
                    case 4: BookAppointment(); break;
                    case 5: ViewPatientAppointments(); break;
                    case 6: ViewAllAppointments(); break;
                    case 7:
                        Console.WriteLine(" Thank you for using Oman Clinic Appointment System. Goodbye!");
                        break;
                    default:
                        Console.WriteLine(" Invalid choice. Try again.");
                        break;
                }

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("--------------------------------------------------------------");


            } while (choice != 7);
        }

        static void RegisterPatient()
        {
            Console.WriteLine("-- Register New Patient --");
            Console.Write("Enter Patient Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter National ID: ");
            string nationalId = Console.ReadLine();

            if (patients.Any(p => p.NationalID == nationalId))
            {
                Console.WriteLine("⚠️ Patient with this ID already exists!");
                return;
            }

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();
            patients.Add(new Patient(name, nationalId, phone));
            Console.WriteLine("✅ Patient registered successfully!");
        }

        static void AddDoctor()
        {
            Console.WriteLine("-- Add New Doctor --");
            Console.Write("Enter Doctor Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Specialty: ");
            string specialty = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            if (doctors.Any(d => d.Name == name))
            {
                Console.WriteLine(" Doctor already exists!");
                return;
            }

            doctors.Add(new Doctor(name, specialty, phone));
            Console.WriteLine(" Doctor added successfully!");
        }

        static void SearchDoctor()
        {
            Console.WriteLine(" Search Doctor by Specialty ");
            Console.Write("Enter Specialty to search: ");
            string specialty = Console.ReadLine();
            var results = doctors.Where(d => d.Specialty.Equals(specialty, StringComparison.OrdinalIgnoreCase)).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine(" No doctors found for this specialty.");
            }
            else
            {
                Console.WriteLine(" Doctors Found:");
                foreach (var doctor in results)
                {
                    Console.WriteLine($"-{doctor.Name} | Phone: {doctor.Phone}");
                }
            }
        }

        static void BookAppointment()
        {
            Console.WriteLine("-- Book Appointment --");
            Console.Write("Enter Patient National ID: ");
            string nationalId = Console.ReadLine();
            var patient = patients.FirstOrDefault(p => p.NationalID == nationalId);
            if (patient == null)
            {
                Console.WriteLine(" Patient not found.");
                return;
            }

            Console.Write("Enter Doctor Name: ");
            string doctorName = Console.ReadLine();
            var doctor = doctors.FirstOrDefault(d => d.Name.Equals(doctorName, StringComparison.OrdinalIgnoreCase));
            if (doctor == null)
            {
                Console.WriteLine(" Doctor not found.");
                return;
            }

            Console.Write("Enter Appointment Date (dd/mm/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine(" Invalid date format.");
                return;
            }

            if (appointments.Any(a => a.Doctor.Name == doctor.Name && a.Date.Date == date.Date))
            {
                Console.WriteLine("Doctor already has an appointment on this day.");
                return;
            }

            appointments.Add(new Appointment(patient, doctor, date));
            Console.WriteLine("Appointment booked successfully!");
        }

        static void ViewPatientAppointments()
        {
            Console.WriteLine(" View Patient Appointments ");
            Console.Write("Enter Patient National ID: ");
            string nationalId = Console.ReadLine();
            var patient = patients.FirstOrDefault(p => p.NationalID == nationalId);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            var patientAppointments = appointments.Where(a => a.Patient.NationalID == nationalId).ToList();
            if (patientAppointments.Count == 0)
            {
                Console.WriteLine("No appointments found for this patient.");
                return;
            }

            Console.WriteLine($"Appointments for {patient.Name}:");
            foreach (var a in patientAppointments)
            {
                Console.WriteLine($"- Date: {a.Date:dd/MM/yyyy} | Doctor: {a.Doctor.Name} | Specialty: {a.Doctor.Specialty}");
            }
        }

        static void ViewAllAppointments()
        {
            Console.WriteLine(" View All Appointments ");
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found.");
                return;
            }

            Console.WriteLine(" All Booked Appointments:");
            int i = 1;
            foreach (var a in appointments)
            {
                Console.WriteLine($"{i++}. Patient: {a.Patient.Name} | Doctor: {a.Doctor.Name} | Date: {a.Date:dd/MM/yyyy} | Specialty: {a.Doctor.Specialty}");
            }
        }
    }
}
