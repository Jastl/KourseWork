using Registry;

namespace UserInterface
{
    internal static class Proggram
    {
        private static string commandList = "1 - Doctor menu\n2 - Appointments menu\n3 - Parient menu\n4 - Exit\n5 - Save\n6 - Load";
        private static string doctorcommandList = "1 - Add doctor\n2 - Delete doctor\n3 - Show all doctors\n4 - Return";
        public static void Main(string[] args)
        {
            RegistyManager.LoadData();
            while (true)
            {
                Console.WriteLine(commandList);
                switch (Console.ReadLine())
                {
                    case "1":
                        DoctorsMenu();
                        break;
                    case "2":
                        //AppointmentsMenu();
                        break;
                    case "3":
                        // PatientMenu();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("NI");
                        break;
                }
            }
            static void DoctorsMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(doctorcommandList);
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Write("Doctors name: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Doctors surname: ");
                            string lastName = Console.ReadLine();
                            Console.Write("Doctors specialization: ");
                            string specialization = Console.ReadLine();
                            RegistyManager.AddDoctor(firstName, lastName, specialization);
                            Console.WriteLine("Doctor added");
                            break;
                        case "2":
                            foreach (var doctor in RegistyManager.GetDoctors())
                            {
                                if (doctor != null)
                                {
                                    Console.WriteLine(doctor);
                                }
                            }
                            Console.Write("Choose doctor ID to delete ");
                            if (int.TryParse(Console.ReadLine(), out int doctorId))
                            {
                                RegistyManager.RemoveDoctor(doctorId);
                                Console.WriteLine("doctor removed");
                            }
                            else
                            {
                                Console.WriteLine("ID is wrong");
                            }
                            break;
                        case "3":
                            Console.WriteLine("List of doctors:");
                            foreach (var doctor in RegistyManager.GetDoctors())
                            {
                                if (doctor != null)
                                {
                                    Console.WriteLine(doctor);
                                }
                            }
                            break;
                        case "4":
                            return;
                        default:
                            Console.WriteLine("Ni");
                            break;
                    }
                    Console.ReadLine();
                }
            }

        }
    }
}

