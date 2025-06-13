using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DreamMotors
{
    partial class ViewDetail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.richTextBox1 = new RichTextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.pictureBox1 = new PictureBox();
            this.label4 = new Label();
            this.label5 = new Label();
            this.btnAddToCart = new Button();
            this.label6 = new Label();
            this.label7 = new Label();
            this.richTextBox2 = new RichTextBox();
            this.label8 = new Label();
            this.label9 = new Label();
            this.label10 = new Label();
            this.label11 = new Label();
            this.label12 = new Label();
            this.label13 = new Label();
            this.label14 = new Label();
            this.label15 = new Label();
            this.label16 = new Label();
            this.pictureBox2 = new PictureBox();

            ((ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((ISupportInitialize)(this.pictureBox2)).BeginInit();

            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new Point(1, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new Size(976, 42);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.BackColor = Color.White;
            this.richTextBox1.BorderStyle = BorderStyle.None;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(75, 20);
            this.label1.Name = "label1";
            this.label1.Size = new Size(110, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dream Motors";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(788, 20);
            this.label2.Name = "label2";
            this.label2.Size = new Size(74, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Inventory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(885, 20);
            this.label3.Name = "label3";
            this.label3.Size = new Size(60, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Brands";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DreamMotors.Properties.Resources.camry;
            this.pictureBox1.Location = new Point(1, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(492, 461);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold);
            this.label4.Location = new Point(538, 71);
            this.label4.Name = "label4";
            this.label4.Size = new Size(505, 61);
            this.label4.TabIndex = 5;
            this.label4.Text = "2023 Toyota Camry";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            this.label5.Location = new Point(570, 124);
            this.label5.Name = "label5";
            this.label5.Size = new Size(86, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Excellent";
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = Color.Black;
            this.btnAddToCart.ForeColor = SystemColors.ButtonHighlight;
            this.btnAddToCart.Location = new Point(545, 523);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new Size(432, 38);
            this.btnAddToCart.TabIndex = 25;
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new EventHandler(this.btnAddToCart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            this.label6.Location = new Point(653, 122);
            this.label6.Name = "label6";
            this.label6.Size = new Size(67, 22);
            this.label6.TabIndex = 7;
            this.label6.Text = "Sedan";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold);
            this.label7.ForeColor = Color.Green;
            this.label7.Location = new Point(554, 173);
            this.label7.Name = "label7";
            this.label7.Size = new Size(223, 61);
            this.label7.TabIndex = 8;
            this.label7.Text = "$28,000";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new Point(545, 309);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new Size(427, 194);
            this.richTextBox2.TabIndex = 10;
            this.richTextBox2.Text = "";
            this.richTextBox2.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold);
            this.label8.Location = new Point(567, 254);
            this.label8.Name = "label8";
            this.label8.Size = new Size(396, 52);
            this.label8.TabIndex = 11;
            this.label8.Text = "Key Specifications";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            this.label9.Location = new Point(580, 370);
            this.label9.Name = "label9";
            this.label9.Size = new Size(74, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "Mileage";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            this.label10.Location = new Point(845, 370);
            this.label10.Name = "label10";
            this.label10.Size = new Size(122, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "Transmission";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            this.label11.Location = new Point(580, 430);
            this.label11.Name = "label11";
            this.label11.Size = new Size(91, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "Fuel Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            this.label12.Location = new Point(845, 430);
            this.label12.Name = "label12";
            this.label12.Size = new Size(47, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "Year";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            this.label13.Location = new Point(580, 398);
            this.label13.Name = "label13";
            this.label13.Size = new Size(115, 20);
            this.label13.TabIndex = 16;
            this.label13.Text = "15,000 miles";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            this.label14.Location = new Point(845, 398);
            this.label14.Name = "label14";
            this.label14.Size = new Size(93, 20);
            this.label14.TabIndex = 17;
            this.label14.Text = "Automatic";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            this.label15.Location = new Point(580, 452);
            this.label15.Name = "label15";
            this.label15.Size = new Size(83, 20);
            this.label15.TabIndex = 18;
            this.label15.Text = "Gasoline";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            this.label16.Location = new Point(845, 452);
            this.label16.Name = "label16";
            this.label16.Size = new Size(49, 20);
            this.label16.TabIndex = 19;
            this.label16.Text = "2023";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DreamMotors.Properties.Resources.Screenshot106;
            this.pictureBox2.Location = new Point(22, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(47, 32);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;

            // 
            // ViewDetail
            // 
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1084, 600);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);

            this.Name = "ViewDetail";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Dream Motors - View Details";
            this.Load += new EventHandler(this.ViewDetail_Load);

            ((ISupportInitialize)(this.pictureBox1)).EndInit();
            ((ISupportInitialize)(this.pictureBox2)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Button btnAddToCart;
        private RichTextBox richTextBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private RichTextBox richTextBox2;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private PictureBox pictureBox2;
    }
}
