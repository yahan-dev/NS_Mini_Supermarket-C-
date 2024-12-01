using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS_Mini_SuperMarket
{
    public static class UserSession
    {
        public static bool IsAdmin { get; set; }

        // Static constructor to initialize static members
        static UserSession()
        {
            IsAdmin = false; // Initialize the IsAdmin property
        }
    }
}
