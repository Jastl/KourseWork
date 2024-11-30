namespace Registry
{
    public class Doctor : IIdenteficable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public Dictionary<DateTime, bool> Schedule { get; set; } = new Dictionary<DateTime, bool>();

        public Doctor(string firstName, string lastName, string specialization)
        {
            FirstName = firstName;
            LastName = lastName;
            Specialization = specialization;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {FirstName}, Surname: {LastName}, Specialization: {Specialization}";
        }
    }
}
