using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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

        // Helper to hash password using SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox3.Text.Trim();
            string oldPassword = textBox4.Text;
            string newPassword = textBox2.Text;
            string confirmPassword = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(oldPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
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

                string safeEmail = email.Replace("@", "_at_").Replace(".", "_");
                string[] userFiles = Directory.GetFiles(userFolder, $"{safeEmail}_*.txt");

                if (userFiles.Length == 0)
                {
                    MessageBox.Show("User with this email not found.", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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

                string[] lines = File.ReadAllLines(latestFile);

                int pwdLineIndex = -1;
                string storedHashedPassword = null;

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith("Password Hash: "))
                    {
                        pwdLineIndex = i;
                        storedHashedPassword = lines[i].Substring("Password Hash: ".Length);
                        break;
                    }
                }

                if (pwdLineIndex == -1 || string.IsNullOrEmpty(storedHashedPassword))
                {
                    MessageBox.Show("Password info missing in user file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hashedOldPassword = HashPassword(oldPassword);
                if (storedHashedPassword != hashedOldPassword)
                {
                    MessageBox.Show("Old password is incorrect.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hashedNewPassword = HashPassword(newPassword);
                lines[pwdLineIndex] = "Password Hash: " + hashedNewPassword;
                File.WriteAllLines(latestFile, lines);

                MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirect to Login
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset_Load(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
    }
}
