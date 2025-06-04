using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DreamMotors
{
    public partial class Reset : Form
    {
        private readonly string userFolder = Path.Combine(Application.StartupPath, "UserData");

        public Reset()
        {
            InitializeComponent();
        }

        // Empty event handlers (avoid errors)
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox3.Text.Trim();
            string oldPassword = textBox4.Text;
            string newPassword = textBox2.Text;
            string confirmPassword = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(oldPassword) ||
                string.IsNullOrEmpty(newPassword) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirmation do not match.", "Mismatch Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!Directory.Exists(userFolder))
                {
                    MessageBox.Show("No user data folder found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create safe email for filename pattern
                string safeEmail = email.Replace("@", "_at_").Replace(".", "_");

                // Find all user files for this email
                string[] userFiles = Directory.GetFiles(userFolder, $"{safeEmail}_*.txt");

                if (userFiles.Length == 0)
                {
                    MessageBox.Show("User with this email not found.", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Find latest file by ticks suffix
                string latestFile = null;
                long latestTicks = 0;
                foreach (var file in userFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    int underscoreIndex = fileName.LastIndexOf('_');
                    if (underscoreIndex > 0)
                    {
                        string ticksStr = fileName.Substring(underscoreIndex + 1);
                        if (long.TryParse(ticksStr, out long ticks) && ticks > latestTicks)
                        {
                            latestTicks = ticks;
                            latestFile = file;
                        }
                    }
                }

                if (latestFile == null)
                {
                    MessageBox.Show("User file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Read all lines
                string[] lines = File.ReadAllLines(latestFile);

                // Find password line index and verify old password
                int pwdLineIndex = -1;
                string storedPassword = null;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith("Password: "))
                    {
                        pwdLineIndex = i;
                        storedPassword = lines[i].Substring("Password: ".Length);
                        break;
                    }
                }

                if (pwdLineIndex == -1)
                {
                    MessageBox.Show("Password info missing in user file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (storedPassword != oldPassword)
                {
                    MessageBox.Show("Old password is incorrect.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update password line
                lines[pwdLineIndex] = "Password: " + newPassword;

                // Save back to file
                File.WriteAllLines(latestFile, lines);

                MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
