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
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        public class Car
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public Image Image { get; set; }
        }

        private List<Car> carList = new List<Car>();

        private void Inventory_Load(object sender, EventArgs e)
        {
            LoadCars();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Low to High");
            comboBox1.Items.Add("High to Low");
            comboBox1.SelectedIndex = 0;
        }

        private void LoadCars()
        {
            carList.Clear();

            carList.Add(new Car { Name = "2023 Toyota Camry", Price = 28000, Image = Properties.Resources.camry });
            carList.Add(new Car { Name = "2023 Toyota Corolla", Price = 23000, Image = Properties.Resources.corolla });
            carList.Add(new Car { Name = "2023 Toyota RAV4", Price = 32000, Image = Properties.Resources.rav4 });
            carList.Add(new Car { Name = "2023 Toyota Aqua", Price = 23000, Image = Properties.Resources.aqua });
            carList.Add(new Car { Name = "2023 Toyota Fortuner", Price = 53000, Image = Properties.Resources.Fortuner });
            carList.Add(new Car { Name = "2023 Toyota Prius", Price = 26000, Image = Properties.Resources.prius });
            carList.Add(new Car { Name = "2023 Toyota Yaris", Price = 20000, Image = Properties.Resources.yaris });
            carList.Add(new Car { Name = "2023 Toyota Highlander", Price = 45000, Image = Properties.Resources.highlander });

            DisplayCars(carList);
        }

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
                    Font = new Font("Arial", 10)
                };

                Button btnView = new Button
                {
                    Text = "View Details",
                    Width = 230,
                    Location = new Point(10, 230),
                    BackColor = Color.Black,
                    ForeColor = Color.White
                };

                if (car.Name.Contains("Camry"))
                {
                    btnView.Click += (s, e) =>
                    {
                        ViewDetail detailsForm = new ViewDetail();
                        detailsForm.Show();
                        this.Hide();

                    };
                }

                carPanel.Controls.Add(pb);
                carPanel.Controls.Add(lblName);
                carPanel.Controls.Add(lblPrice);
                carPanel.Controls.Add(btnView);

                flowLayoutPanel1.Controls.Add(carPanel);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carList == null || carList.Count == 0) return;

            var selected = comboBox1.SelectedItem?.ToString();
            if (selected == "High to Low")
            {
                var sorted = carList.OrderByDescending(c => c.Price).ToList();
                DisplayCars(sorted);
            }
            else if (selected == "Low to High")
            {
                var sorted = carList.OrderBy(c => c.Price).ToList();
                DisplayCars(sorted);
            }
        }
    }
}
