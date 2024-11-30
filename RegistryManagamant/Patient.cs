﻿namespace Registry
{
    public class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }

        public Patient(string firstName, string lastName, DateTime dateOfDirth, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfDirth;
            PhoneNumber = phoneNumber;
        }
    }
}
