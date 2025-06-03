using System;
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
            // Optionally initialize UI components
        }

        private void label9_Click(object sender, EventArgs e)
        {
            // Optional: handle title click
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Optional: handle password field change
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox4.Text;

            // Example credentials (replace with real validation or database)
            string validEmail = "arya@dreammotors.com";
            string validPassword = "1234";

            if (email == validEmail && password == validPassword)
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirect to DashBoard (make sure DashBoard form exists)
                DashBoard dashboard = new DashBoard();
                dashboard.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
