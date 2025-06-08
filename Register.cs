using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DreamMotors
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        // Email validation using Regex
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string firstName = textBox1.Text.Trim();
            string lastName = textBox2.Text.Trim();
            string email = textBox3.Text.Trim();
            string password = textBox4.Text;
            string confirmPassword = textBox5.Text;

            // Input validation
            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format. Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Save user data
                string folderPath = Path.Combine(Application.StartupPath, "UserData");
                Directory.CreateDirectory(folderPath);

                string safeEmail = email.Replace("@", "_at_").Replace(".", "_");
                string fileName = $"{safeEmail}_{DateTime.Now.Ticks}.txt";
                string filePath = Path.Combine(folderPath, fileName);

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("First Name: " + firstName);
                    writer.WriteLine("Last Name: " + lastName);
                    writer.WriteLine("Email: " + email);
                    writer.WriteLine("Password: " + password); // Never store plain passwords in production!
                }

                MessageBox.Show("Sign-up successful!\nWelcome to DreamMotors!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Navigate to dashboard
                DashBoard dashboard = new DashBoard();
                dashboard.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file to upload";
                openFileDialog.Filter = "All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    try
                    {
                        string uploadFolder = Path.Combine(Application.StartupPath, "UserUploads");
                        Directory.CreateDirectory(uploadFolder);

                        string fileName = Path.GetFileName(selectedFilePath);
                        string destinationPath = Path.Combine(uploadFolder, fileName);

                        File.Copy(selectedFilePath, destinationPath, true);

                        MessageBox.Show("File uploaded and saved to:\n" + destinationPath, "Upload Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error copying file: " + ex.Message, "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

 yubraj_view-details
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Optionally add live email validation feedback here

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
 master
        }
    }
}
