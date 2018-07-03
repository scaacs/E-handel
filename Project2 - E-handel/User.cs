using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2___E_handel
{
    public class User
    {
        public int Security { get; private set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SSN { get; private set; }
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }

        public User(int security, string firstName, string lastName, string email, string password, string ssn, string street, string zipcode, string city)
        {
            Security = security;
            Firstname = firstName;
            Lastname = lastName;
            Email = email;
            Password = password;
            SSN = ssn;
            Street = street;
            Zipcode = zipcode;
            City = city;
        }
    }
}