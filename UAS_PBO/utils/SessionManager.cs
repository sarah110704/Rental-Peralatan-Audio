using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS_PBO.model;

namespace UAS_PBO.utils
{
    public static class SessionManager
    {
        public static int UserID { get; set; } = -1;
        public static string Username { get; set; } = "";
        public static string Role { get; set; } = "";
    }
}
