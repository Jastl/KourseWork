using System;
using System.Data;
using System.Numerics;
using FileManagmant;

namespace Registry
{
    public static class RegistyManager
    {
        private static List<Doctor> doctors;
        private static List<Appointment> appointments;
        public static readonly string savePath = "C:/";

        public static void AddAppointment(Patient patient, int doctorId, DateTime dateTime)
        {
            if (doctors[doctorId] == null)
            {
                Console.WriteLine("Лікаря з таким id не існує.");
            }
            AddElement<Appointment>(appointments, new Appointment(patient, doctors[doctorId], dateTime));
        }

        public static void RemoveAppointment(int id) => appointments[id] = null;

        public static void AddDoctor(string firstName, string lastName, string specification) => AddElement<Doctor>(doctors, new Doctor(firstName, lastName, specification));
        public static void RemoveDoctor(int id) => doctors[id] = null;
        public static void SaveData()
        {
            FileManager<Doctor> fileDoctors = new FileManager<Doctor>(savePath + "doctors.txt");
            fileDoctors.SaveData(doctors);
            FileManager<Appointment> fileAppointments = new FileManager<Appointment>(savePath + "appointments.txt");
            fileAppointments.SaveData(appointments);
        }


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
