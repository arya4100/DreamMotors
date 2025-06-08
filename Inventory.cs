using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DreamMotors
{
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }

        // Car class to hold data
        public class Car
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public Image Image { get; set; }
        }

        // Car list
        private List<Car> carList = new List<Car>();

        // Load car data
        private void LoadCars()
        {
            carList.Clear();

            carList.Add(new Car
            {
                Name = "2023 Toyota Camry",
                Price = 28000,
                Image = Properties.Resources.camry
            });

            carList.Add(new Car
            {
                Name = "2023 Toyota Corolla",
                Price = 23000,
                Image = Properties.Resources.corolla
            });

            carList.Add(new Car
            {
                Name = "2023 Toyota RAV4",
                Price = 32000,
                Image = Properties.Resources.rav4
            });

            DisplayCars(carList);
        }

        // Display logic for flow layout
        private void DisplayCars(List<Car> cars)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var car in cars)
            {
                Panel carPanel = new Panel
                {
                    Width = 250,
                    Height = 320,
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle
                };

                PictureBox pb = new PictureBox
                {
                    Image = car.Image,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 230,
                    Height = 150,
                    Location = new Point(10, 10)
                };

                Label lblName = new Label
                {
                    Text = car.Name,
                    Location = new Point(10, 170),
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };

                Label lblPrice = new Label
                {
                    Text = "$ " + car.Price.ToString("N0"),
                    Location = new Point(10, 195),
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Regular)
                };

                Button btnView = new Button
                {
                    Text = "View Details",
                    Width = 230,
                    Location = new Point(10, 230),
                    BackColor = Color.Black,
                    ForeColor = Color.White
                };

                carPanel.Controls.Add(pb);
                carPanel.Controls.Add(lblName);
                carPanel.Controls.Add(lblPrice);
                carPanel.Controls.Add(btnView);

                flowLayoutPanel1.Controls.Add(carPanel);
            }
        }

        // Sort selection
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "High to Low")
            {
                var sorted = carList.OrderByDescending(c => c.Price).ToList();
                DisplayCars(sorted);
            }
            else if (comboBox1.SelectedItem.ToString() == "Low to High")
            {
                var sorted = carList.OrderBy(c => c.Price).ToList();
                DisplayCars(sorted);
            }
        }

        // Form Load
        private void Inventory_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Low to High");
            comboBox1.Items.Add("High to Low");
            comboBox1.SelectedIndex = 0;

            LoadCars();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
