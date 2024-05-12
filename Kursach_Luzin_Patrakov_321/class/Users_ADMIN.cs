using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_Luzin_Patrakov_321
{
    internal class Users_ADMIN
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }

        public Users_ADMIN(int userid, string login, string pass, string lastname, string firstname, string gender, string role)
        {
            UserID = userid;
            Login = login;
            Password = pass;
            LastName = lastname;
            FirstName = firstname;
            Gender = gender;
            Role = role;
        }
    }
}
