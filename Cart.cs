using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DreamMotors
{
    public partial class Cart : Form
    {
        // Shared cart items across all Cart instances
        private static List<CartItem> cartItems = new List<CartItem>();

        public Cart()
        {
            InitializeComponent();
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            listBox1.Items.Clear();

            decimal total = 0;
            int totalItems = 0;

            foreach (var item in cartItems)
            {
                listBox1.Items.Add(item.ToString());
                total += item.Price * item.Quantity;
                totalItems += item.Quantity;
            }

            textBox1.Text = totalItems.ToString();        // Total quantity
            textBox2.Text = $"${total:0.00}";             // Total price
        }

        public void AddToCart(string productName, int quantity, decimal price)
        {
            var existingItem = cartItems.FirstOrDefault(i => i.Name == productName);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cartItems.Add(new CartItem
                {
                    Name = productName,
                    Quantity = quantity,
                    Price = price
                });
            }

            LoadCartItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < cartItems.Count)
            {
                cartItems.RemoveAt(selectedIndex);
                LoadCartItems();
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

            MessageBox.Show("Thank you for your purchase!", "Checkout Complete");
            cartItems.Clear();
            LoadCartItems();
        }

        // Optional empty handlers to avoid errors if Designer expects them
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}
