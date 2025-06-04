using System;
using System.IO;
using System.Windows.Forms;

namespace DreamMotors
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        // Event handler for form load
        private void Login_Load(object sender, EventArgs e)
        {
            // Optional initialization code here
        }

        // Event handler for label9 click
        private void label9_Click(object sender, EventArgs e)
        {
            // Optional label click logic here
        }

        // Event handler for textBox4 text changed
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Optional password box text changed logic here
        }

        // Login button click event
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

                // Generate the safe email string for file search
                string safeEmail = email.Replace("@", "_at_").Replace(".", "_");
                string[] userFiles = Directory.GetFiles(folderPath, $"{safeEmail}_*.txt");

                if (userFiles.Length == 0)
                {
                    MessageBox.Show("No account found with this email.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Find the latest registration file by ticks in filename
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

                // Read stored password from file
                string[] lines = File.ReadAllLines(latestFile);
                string storedPassword = null;
                foreach (string line in lines)
                {
                    if (line.StartsWith("Password: "))
                    {
                        storedPassword = line.Substring("Password: ".Length);
                        break;
                    }
                }

                if (storedPassword == null)
                {
                    MessageBox.Show("Password not found in user data.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (password == storedPassword)
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reset resetForm = new Reset();
            resetForm.Show();
            this.Hide();  // Hide Login while Reset is open
        }

    }
}
