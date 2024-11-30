using System;
using System.Data;
using System.Numerics;
using FileManagmant;

namespace Registry
{
    public static class RegistyManager
    {
        private static List<Doctor> doctors = new List<Doctor>();
        private static List<Appointment> appointments = new List<Appointment>();
        public static readonly string savePathDoctors = @"D:\doctors.json";
        public static readonly string savePathAppointment = @"D:\apointments.json";

        public static void AddAppointment(Patient patient, int doctorId, DateTime dateTime)
        {
            if (doctors[doctorId] == null)
            {
                Console.WriteLine("Лікаря з таким id не існує.");
            }
            AddElement<Appointment>(appointments, new Appointment(patient, doctors[doctorId], dateTime));
            SaveData();
        }

        public static void RemoveAppointment(int id)
        {
            appointments[id] = null;
            SaveData();
        }

        public static void AddDoctor(string firstName, string lastName, string specification)
        {
            AddElement<Doctor>(doctors, new Doctor(firstName, lastName, specification));
            SaveData();
        }
        public static void RemoveDoctor(int id) 
        {
            doctors[id] = null;
            SaveData();
        }
        public static void SaveData()
        {
            FileManager<Doctor> fileDoctors = new FileManager<Doctor>(savePathDoctors);
            fileDoctors.SaveData(doctors);
            FileManager<Appointment> fileAppointments = new FileManager<Appointment>(savePathAppointment);
            fileAppointments.SaveData(appointments);
        }
        public static void LoadData()
        {
            FileManager<Doctor> fileDoctors = new FileManager<Doctor>(savePathDoctors);
            doctors = fileDoctors.LoadData();
            FileManager<Appointment> fileAppointments = new FileManager<Appointment>(savePathAppointment);
            appointments = fileAppointments.LoadData();
        }
        public static List<Doctor> GetDoctors() => doctors;

        public static List<Appointment> GetAppointments() => appointments;
        private static void AddElement<T>(List<T> array, T element) where T : IIdenteficable 
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (object.Equals(array[i], default(T)))
                {
                    array[i] = element;
                    element.Id = i;
                    return;
                }
            }
            array.Add(element);
            array[^1] = element;
            element.Id = array.Count - 1;
        }
    }
}
