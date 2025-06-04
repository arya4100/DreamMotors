using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DreamMotors
{
    public partial class Reset : Form
    {
        private string filePath = @"C:\DreamMotorsData\users.txt";
        public Reset()
        {
            InitializeComponent();
            EnsureFileExists();
        }

        private void EnsureFileExists()
        {
            string folder = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(filePath))
            {
                // Create file with a default user
                File.WriteAllText(filePath, "admin,1234\n");
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string confirmPassword = textBox1.Text.Trim();
            string newPassword = textBox2.Text;
            string email = textBox3.Text;
            string oldPassword = textBox4.Text;

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(oldPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirmation do not match.");
                return;
            }

            bool userFound = false;
            List<string> updatedLines = new List<string>();

            foreach (var line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string existingEmail = parts[0].Trim();
                    string existingPassword = parts[1].Trim();

                    if (string.Equals(existingEmail, email, StringComparison.OrdinalIgnoreCase))
                        {
                        if (existingPassword == oldPassword)
                        {
                            updatedLines.Add($"{email},{newPassword}");
                            userFound = true;
                        }
                        else
                        {
                            MessageBox.Show("Old password is incorrect.");
                            return;
                        }
                    }
                    else
                    {
                        updatedLines.Add(line); // Preserve other users
                    }
                }
            }

            if (!userFound)
            {
                MessageBox.Show("Email not found.");
                return;
            }

            File.WriteAllLines(filePath, updatedLines);
            MessageBox.Show("Password updated successfully!");
            this.Close();
        }
    }
}