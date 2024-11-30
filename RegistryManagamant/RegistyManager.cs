using System;
using System.Data;
using System.Numerics;

namespace Registry
{
    public static class RegistyManager //змінив на public 
    {
        private static Doctor[] doctors = new Doctor[0]; //ініцілізував спроба вирішити проблему ТЕЖ НЕЗНАЮ ЧИ ВОНО ПОТРІБНО НАМ БУДЕ ЯКЩО МИ БУДЕМО З JSON-А БРАТИ АЛЕ ПОКИ ТАК ПОКИ Я РОБЛЮ ПЕРЕВІРКИ
        private static Appointment[] appointments = new Appointment[0];// ініцілізував спроба вирішити проблему

        public static void AddAppointment(Patient patient, int doctorId, DateTime dateTime)
        {
            if (doctors[doctorId] == null)
            {
                Console.WriteLine("Лікаря з таким id не існує.");
            }
            AddElement<Appointment>(ref appointments, new Appointment(patient, doctors[doctorId], dateTime));//ref додав
        }

        public static void RemoveAppointment(int id) => appointments[id] = null;

        public static void AddDoctor(string firstName, string lastName, string specification) => AddElement<Doctor>(ref doctors, new Doctor(firstName, lastName, specification));//ref додав
        public static void RemoveDoctor(int id) => doctors[id] = null;
        public static Doctor[] GetDoctors()// додав щоб отримувати докторів впринципі я не знаю чи потрібно переписувати під json
        {
            return doctors;
        }
        private static void AddElement<T>(ref T[] array, T element) where T : IIdenteficable //(T[] array, T element) --> (ref T[] array, T element) бо воно без нього не додає в масив нічого 
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
