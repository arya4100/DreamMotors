using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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

        // Password strength validation
        private bool IsStrongPassword(string password)
        {
            // At least 8 characters, 1 uppercase, 1 lowercase, 1 number, 1 special character
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        // Hash password for secure storage
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
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

            if (!IsStrongPassword(password))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain uppercase, lowercase, number, and special character.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // Hash the password before storing
                string hashedPassword = HashPassword(password);

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("First Name: " + firstName);
                    writer.WriteLine("Last Name: " + lastName);
                    writer.WriteLine("Email: " + email);
                    writer.WriteLine("Password Hash: " + hashedPassword);
                    writer.WriteLine("Registration Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif|PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    string fileExtension = Path.GetExtension(selectedFilePath).ToLower();

                    // Validate file type and size
                    if (!IsValidFileType(fileExtension))
                    {
                        MessageBox.Show("Invalid file type. Please upload an image or PDF file.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    FileInfo fileInfo = new FileInfo(selectedFilePath);
                    if (fileInfo.Length > 5 * 1024 * 1024) // 5MB limit
                    {
                        MessageBox.Show("File size exceeds the 5MB limit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        string uploadFolder = Path.Combine(Application.StartupPath, "UserUploads");
                        Directory.CreateDirectory(uploadFolder);

                        string fileName = $"{DateTime.Now.Ticks}_{Path.GetFileName(selectedFilePath)}";
                        string destinationPath = Path.Combine(uploadFolder, fileName);

                        File.Copy(selectedFilePath, destinationPath, true);

                        MessageBox.Show("File uploaded successfully!", "Upload Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Update UI to show uploaded file (if you have a label or picture box for this)
                        // lblFileName.Text = Path.GetFileName(selectedFilePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error copying file: " + ex.Message, "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool IsValidFileType(string extension)
        {
            string[] validExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".pdf" };
            return Array.IndexOf(validExtensions, extension) >= 0;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Live email validation feedback
            string email = textBox3.Text.Trim();
            if (!string.IsNullOrEmpty(email))
            {
                if (IsValidEmail(email))
                {
                    // Visual indication of valid email (e.g., change border color)
                    textBox3.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    textBox3.BackColor = System.Drawing.Color.LightPink;
                }
            }
            else
            {
                textBox3.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}
