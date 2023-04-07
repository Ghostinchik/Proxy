using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proxy.Proxy;

namespace Proxy
{
    public partial class Form1 : Form
    {

        private List<User> users = new List<User>();
        private FunctionalityProxy Functionality;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            User user = new User(username, password);
            users.Add(user);

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            User user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                user.IsAuthenticated = true;

                Functionality = new FunctionalityProxy(user);
                Functionality.PerformFunctionality();
                MessageBox.Show("Авторизація успішна");
            }
            else
            {
                MessageBox.Show("Неправильне ім'я користувача або пароль");
            }
        }
    }
}
