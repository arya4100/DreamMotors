using System;
using System.IO;
using System.Windows.Forms;

namespace DreamMotors
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||      // First Name
                string.IsNullOrWhiteSpace(textBox2.Text) ||      // Last Name
                string.IsNullOrWhiteSpace(textBox3.Text) ||      // Email
                string.IsNullOrWhiteSpace(textBox4.Text) ||      // Password
                string.IsNullOrWhiteSpace(textBox5.Text) ||      // Confirm Password
                textBox4.Text != textBox5.Text)                   // Password match check
            {
                MessageBox.Show("Please fill all fields correctly and ensure passwords match!", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create directory to store user data
                string folderPath = Path.Combine(Application.StartupPath, "UserData");
                Directory.CreateDirectory(folderPath);

                // Generate safe file name
                string safeEmail = textBox3.Text.Replace("@", "_at_").Replace(".", "_");
                string fileName = $"{safeEmail}_{DateTime.Now.Ticks}.txt";
                string filePath = Path.Combine(folderPath, fileName);

                // Save data to file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("First Name: " + textBox1.Text);
                    writer.WriteLine("Last Name: " + textBox2.Text);
                    writer.WriteLine("Email: " + textBox3.Text);
                    writer.WriteLine("Password: " + textBox4.Text); // Don't store raw passwords in real apps!
                }

                MessageBox.Show("Sign-in successfully!\nWelcome to DreamMotors!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open dashboard
                DashBoard dashboard = new DashBoard();
                dashboard.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        // Create folder for uploads inside application folder
                        string uploadFolder = Path.Combine(Application.StartupPath, "UserUploads");
                        Directory.CreateDirectory(uploadFolder);

                        // Use original file name
                        string fileName = Path.GetFileName(selectedFilePath);
                        string destinationPath = Path.Combine(uploadFolder, fileName);

                        // Copy the selected file to the upload folder, overwrite if exists
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}
