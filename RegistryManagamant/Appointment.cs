namespace Registry
{
    public class Appointment : IIdenteficable
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime DateTime { get; set; }
        public StatusValues Status { get; set; }
        public Appointment(Patient patient, Doctor doctor, DateTime dateTime)
        {
            Patient = patient;
            Doctor = doctor;
            DateTime = dateTime;
            Status = StatusValues.Planned;
        }
        public enum StatusValues
        {
            Planned,
            Completed,
            Cancelled
        }
    }
}
