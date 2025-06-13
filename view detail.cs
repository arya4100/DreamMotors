using System;
using System.Linq;
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
            // Set default specs text for Toyota Camry
            richTextBox2.Text = "• Engine: 2.5L 4-Cylinder\n" +
                                "• Horsepower: 203 hp\n" +
                                "• MPG: 28 city / 39 highway\n" +
                                "• Drivetrain: FWD";
        }

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
                    // Check if Cart form is already open
                    Cart cartForm = Application.OpenForms.OfType<Cart>().FirstOrDefault();
                    if (cartForm == null)
                    {
                        cartForm = new Cart();
                    }

                    // Add item to cart and show cart form
                    cartForm.AddToCart("2023 Toyota Camry", 1, 28000m);
                    cartForm.Show();
                    cartForm.BringToFront();

                    MessageBox.Show("2023 Toyota Camry has been added to your cart successfully!",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding to cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Optional event handler if you want to react to richTextBox text changes
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            // You can leave this empty if not needed
        }
    }
}
