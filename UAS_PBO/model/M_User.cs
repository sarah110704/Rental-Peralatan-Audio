using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_PBO.model
{
    internal class M_User
    {
        string id, firstName, lastName,phonenumber, username, password, role, gender, address;

        public M_User()
        {

        }

        public M_User(string id, string firstName, string lastName, string phonenumber, string username, string password, string role, string gender, string address)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phonenumber = phonenumber;
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Gender = gender;
            this.Address = address;
        }

        public string Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Address { get => address; set => address = value; }
    }
}
