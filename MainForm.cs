using System;
using System.Windows.Forms;

namespace DreamMotors
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Dream Motors - Dashboard";
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label welcomeLabel = new Label();
            welcomeLabel.Text = "Welcome to Dream Motors!";
            welcomeLabel.AutoSize = true;
            welcomeLabel.Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
            welcomeLabel.Location = new System.Drawing.Point(250, 250);
            this.Controls.Add(welcomeLabel);
        }
    }
}
