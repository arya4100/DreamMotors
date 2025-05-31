using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DreamMotors
{
    public partial class Login : Form

    {

       
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string enteredEmail = textBoxEmail.Text.Trim();
            string enteredPassword = textBoxPassword.Text;

            Dictionary<string, string> userCredentials = new Dictionary<string, string>()
    {
        { "admin@gmail.com", "admin123" },
        { "user1@gmail.com", "123" },
        { "user2@gmail.com", "123" },
        { "user3@gmail.com", "123" },
        { "user4@gmail.com", "123" }
    };

            if (userCredentials.ContainsKey(enteredEmail) && userCredentials[enteredEmail] == enteredPassword)
            {
                // Open Dashboard and hide Login form
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide(); // Hides the login form
            }
            else
            {
                MessageBox.Show("Invalid email or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
