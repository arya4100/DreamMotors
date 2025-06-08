using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace DreamMotors
{
    public partial class Cart : Form
    {
        private List<CartItem> cartItems = new List<CartItem>();

        public Cart()
        {
            InitializeComponent();
            UpdateCartDisplay();
        }

        public class CartItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }

            public override string ToString()
            {
                return $"{Name} (x{Quantity}) - ${Price * Quantity}";
            }
        }

        // Call this method whenever the cart is updated
        private void UpdateCartDisplay()
        {
            listBox1.Items.Clear();
            decimal total = 0;

            foreach (CartItem item in cartItems)
            {
                listBox1.Items.Add(item);
                total += item.Price * item.Quantity;
            }

            textBox1.Text = total.ToString("0.00"); // Total price
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < cartItems.Count)
            {
                cartItems.RemoveAt(selectedIndex);
                UpdateCartDisplay();
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty.");
                return;
            }

            MessageBox.Show("Thank you for your purchase!\nTotal: $" + textBox1.Text);
            cartItems.Clear();
            UpdateCartDisplay();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
