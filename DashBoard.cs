using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DreamMotors
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();

            // Hook up the button click events (if not wired up in Designer)
            //btnLogin.Click += btnLogin_Click;
            //btnRegister.Click += btnRegister_Click;
        }

        // Login button click - opens Login form
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();  // Hide Dashboard while Login is open
        }

        // Register button click - opens Register form
        private void btnRegister_Click(object sender, EventArgs e)
        {
            //Register registerForm = new Register();
            //registerForm.Show();
            //this.Hide();  // Hide Dashboard while Register is open
        }

        // Optional: handle labels or other buttons if needed
        private void label9_Click(object sender, EventArgs e)
        {
            // your code here if needed
        }

        private void label10_Click(object sender, EventArgs e)
        {
            // your code here if needed
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide();  // Hide Dashboard while Register is open
            // your code here if needed
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            linkLabel1.Visible = false;
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateaccount_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide();  // Hide Dashboard while Register is open
        }
    }
}
