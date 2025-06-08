using System;
using System.Drawing;
using System.Windows.Forms;

namespace DreamMotors
{
    public partial class ViewDetail : Form
    {
        public ViewDetail()
        {
            InitializeComponent();
        }

        private void ViewDetail_Load(object sender, EventArgs e)
        {
            // Form load initialization logic
            this.WindowState = FormWindowState.Normal;
            this.CenterToScreen();
        }

        // Action Button Event Handlers
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Vehicle added to cart successfully!",
                              "Success",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding to cart: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void btnEmailInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // Here you would typically open an email form or send an email
                MessageBox.Show("Email request sent! We will contact you shortly with more information about this vehicle.",
                              "Email Sent",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void btnScheduleDrive_Click(object sender, EventArgs e)
        {
            try
            {
                // Here you would typically open a scheduling form
                DialogResult result = MessageBox.Show("Would you like to schedule a test drive for this vehicle?",
                                                    "Schedule Test Drive",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Test drive scheduled! We will contact you to confirm the appointment.",
                                  "Scheduled",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error scheduling test drive: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        // Navigation Button Event Handlers
        private void btnInventory_Click(object sender, EventArgs e)
        {

        }

        private void btnBrands_Click(object sender, EventArgs e)
        {
            try
            {
                // Navigate to brands form
                MessageBox.Show("Opening Brands page...",
                              "Navigation",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                // Example navigation:
                // BrandsForm brandsForm = new BrandsForm();
                // brandsForm.Show();
                // this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening brands: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Navigate to register form
                MessageBox.Show("Opening Registration page...",
                              "Navigation",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                // Example navigation:
                // RegisterForm registerForm = new RegisterForm();
                // registerForm.Show();
                // this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening registration: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        // Method to update car details (you can call this to change the displayed car)
        public void UpdateCarDetails(string carTitle, string condition, string type, string price,
                                   string mileage, string transmission, string fuelType, string year)
        {
            try
            {
                // Find and update the labels
                foreach (Control control in this.Controls)
                {
                    if (control is Label label)
                    {
                        switch (label.Name)
                        {
                            case "lblCarTitle":
                                label.Text = carTitle;
                                break;
                            case "lblCondition":
                                label.Text = condition;
                                break;
                            case "lblType":
                                label.Text = type;
                                break;
                            case "lblPrice":
                                label.Text = price;
                                break;
                            case "lblMileage":
                                label.Text = $"Mileage: {mileage}";
                                break;
                            case "lblTransmission":
                                label.Text = $"Transmission: {transmission}";
                                break;
                            case "lblFuelType":
                                label.Text = $"Fuel Type: {fuelType}";
                                break;
                            case "lblYear":
                                label.Text = $"Year: {year}";
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating car details: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        // Method to update car image
        public void UpdateCarImage(Image newImage)
        {
            try
            {
                foreach (Control control in this.Controls)
                {
                    if (control is PictureBox pictureBox && pictureBox.Size.Width > 500) // Assuming the car image is the large PictureBox
                    {
                        pictureBox.Image = newImage;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating car image: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        // Override the form closing event if needed
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                // Add any cleanup logic here if needed
                base.OnFormClosing(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error closing form: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        // Method to handle any unhandled exceptions
        private void HandleException(Exception ex, string operation)
        {
            string message = $"An error occurred during {operation}:\n\n{ex.Message}";
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCreateaccount_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowseinventory_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ViewDetail_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}