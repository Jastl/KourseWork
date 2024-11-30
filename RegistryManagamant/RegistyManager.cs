using System;
using System.Data;
using System.Numerics;

namespace Registry
{
    internal static class RegistyManager
    {
        private static Doctor[] doctors;
        private static Appointment[] appointments;

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

        private static void AddElement<T>(T[] array, T element) where T : IIdenteficable 
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    array[i] = element;
                    element.Id = i;
                    return;
                }
            }
            Array.Resize(ref array, array.Length + 1);
            array[^1] = element;
            element.Id = array.Length - 1;
        }
    }
}
