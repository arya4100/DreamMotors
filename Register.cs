using System;
using System.Windows.Forms;

namespace DreamMotors
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("Please fill all fields correctly!", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simulated database saving logic
            bool isRegistered = SaveToDatabase(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

            if (isRegistered)
            {
                MessageBox.Show("Sign-in successfully!\nWelcome to DreamMotors!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirect to Dashboard
                DashBoard dashboard = new DashBoard();
               
                dashboard.Show();
                this.Hide(); // Hide registration form instead of closing
            }
            else
            {
                MessageBox.Show("Registration failed. Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool SaveToDatabase(string firstName, string lastName, string email, string password)
        {
            // Simulated database logic
            return !string.IsNullOrEmpty(firstName) &&
                   !string.IsNullOrEmpty(lastName) &&
                   !string.IsNullOrEmpty(email) &&
                   !string.IsNullOrEmpty(password);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }

    internal class Dashboard
    {
        internal void Show()
        {
            throw new NotImplementedException();
        }
    }
}
