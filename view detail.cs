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
            // Form initialization
            this.WindowState = FormWindowState.Normal;
            this.CenterToScreen();
        }

        // Navigation button event handlers
        private void btnInventory_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Navigating to Inventory page...",
                              "Navigation",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                // Here you would typically open the Inventory form
                // InventoryForm inventoryForm = new InventoryForm();
                // inventoryForm.Show();
                // this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrands_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Navigating to Brands page...",
                              "Navigation",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                // Here you would typically open the Brands form
                // BrandsForm brandsForm = new BrandsForm();
                // brandsForm.Show();
                // this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Action button event handlers
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Add 2023 Toyota Camry to your cart?\n\nPrice: $28,000",
                    "Add to Cart",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("2023 Toyota Camry has been added to your cart successfully!",
                                  "Success",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                    // Here you would typically add the item to a shopping cart system
                    // CartManager.AddItem(new CarItem("2023 Toyota Camry", 28000));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding to cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEmailInfo_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Would you like to receive more information about the 2023 Toyota Camry via email?",
                    "Email Information",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Here you could open an email form or send an automated email
                    string emailBody = "Dear Customer,\n\n" +
                                     "Thank you for your interest in the 2023 Toyota Camry.\n\n" +
                                     "Vehicle Details:\n" +
                                     "- Model: 2023 Toyota Camry\n" +
                                     "- Condition: Excellent\n" +
                                     "- Type: Sedan\n" +
                                     "- Price: $28,000\n" +
                                     "- Mileage: 15,000 miles\n" +
                                     "- Transmission: Automatic\n" +
                                     "- Fuel Type: Gasoline\n\n" +
                                     "Please contact us for more information or to schedule a test drive.\n\n" +
                                     "Best regards,\n" +
                                     "Dream Motors Team";

                    MessageBox.Show("Email information request sent successfully!\n\nWe will contact you shortly with detailed information about this vehicle.",
                                  "Email Sent",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnScheduleTestDrive_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Would you like to schedule a test drive for the 2023 Toyota Camry?",
                    "Schedule Test Drive",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Here you could open a scheduling form
                    MessageBox.Show("Test drive request submitted successfully!\n\n" +
                                  "Our team will contact you within 24 hours to confirm your appointment.\n\n" +
                                  "Vehicle: 2023 Toyota Camry\n" +
                                  "Location: Dream Motors Showroom",
                                  "Test Drive Scheduled",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error scheduling test drive: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to update car details dynamically (for future use)
        public void UpdateCarDetails(string model, string condition, string type, decimal price,
                                   int mileage, string transmission, string fuelType, int year, Image carImage = null)
        {
            try
            {
                // Update car title
                foreach (Control control in this.Controls)
                {
                    if (control is Label label)
                    {
                        if (label.Font.Size > 20) // Assuming this is the main title
                        {
                            label.Text = model;
                        }
                        else if (label.Text.Contains("$"))
                        {
                            label.Text = $"${price:N0}";
                        }
                        else if (label.Text.Contains("miles"))
                        {
                            label.Text = $"{mileage:N0} miles";
                        }
                        else if (label.Text.Contains("Transmission"))
                        {
                            label.Text = transmission;
                        }
                        else if (label.Text.Contains("Fuel Type"))
                        {
                            label.Text = fuelType;
                        }
                        else if (label.Text.Contains("Year") || label.Text == year.ToString())
                        {
                            label.Text = year.ToString();
                        }
                    }
                    else if (control is PictureBox pictureBox && carImage != null)
                    {
                        if (pictureBox.Size.Width > 300) // Assuming this is the main car image
                        {
                            pictureBox.Image = carImage;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating car details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Form closing event
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to close the vehicle details?",
                    "Confirm Close",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                base.OnFormClosing(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error closing form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}