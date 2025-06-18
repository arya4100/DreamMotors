using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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
            // Optional initialization code
        }

        private void label9_Click(object sender, EventArgs e)
        {
            // Optional label click logic
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Optional password change logic
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox4.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string folderPath = Path.Combine(Application.StartupPath, "UserData");
                string safeEmail = email.Replace("@", "_at_").Replace(".", "_");
                string[] userFiles = Directory.GetFiles(folderPath, $"{safeEmail}_*.txt");

                if (userFiles.Length == 0)
                {
                    MessageBox.Show("No account found with this email.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Find the most recent file (latest by ticks)
                string latestFile = null;
                long latestTicks = 0;
                foreach (var file in userFiles)
                {
                    string name = Path.GetFileNameWithoutExtension(file);
                    int underscoreIndex = name.LastIndexOf('_');
                    if (underscoreIndex > 0)
                    {
                        string ticksStr = name.Substring(underscoreIndex + 1);
                        if (long.TryParse(ticksStr, out long ticks) && ticks > latestTicks)
                        {
                            latestTicks = ticks;
                            latestFile = file;
                        }
                    }
                }

                if (latestFile == null)
                {
                    MessageBox.Show("User data file not found.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] lines = File.ReadAllLines(latestFile);
                string storedPasswordHash = null;

                foreach (string line in lines)
                {
                    if (line.StartsWith("Password Hash: "))
                    {
                        storedPasswordHash = line.Substring("Password Hash: ".Length);
                        break;
                    }
                }

                if (storedPasswordHash == null)
                {
                    MessageBox.Show("Password not found in user data.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hashedInput = HashPassword(password);

                if (hashedInput == storedPasswordHash)
                {
                    MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DashBoard dashboard = new DashBoard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Password hashing function (must match registration method)
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reset resetForm = new Reset();
            resetForm.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide();
        }
    }
}
