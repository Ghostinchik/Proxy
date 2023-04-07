using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proxy
{
    internal class Proxy
    {
        public interface IFunctionality
        {
            void PerformFunctionality();
        }

        public class Functionality : IFunctionality
        {
            public void PerformFunctionality()
            {
                MessageBox.Show("Функціонал виконано успішно");
            }
        }

        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public bool IsAuthenticated { get; set; }

            public User(string username, string password)
            {
                Username = username;
                Password = password;
                IsAuthenticated = false;
            }

            public bool Authenticate()
            {
                return true;
            }
        }

        public class FunctionalityProxy : IFunctionality
        {
            private User user;
            private Functionality functionality;

            public FunctionalityProxy(User user)
            {
                this.user = user;
                functionality = new Functionality();
            }

            public void PerformFunctionality()
            {
                if (user.IsAuthenticated)
                {
                    functionality.PerformFunctionality();
                }
                else
                {
                    MessageBox.Show("Доступ заборонено");
                }
            }
        }

    }
}
