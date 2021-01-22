using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Food
{
    public partial class Change_admin_food : Form
    {
        string name, type;
        int cal,image;

        private void Change_admin_food_Load(object sender, EventArgs e)
        {
            bunifuTextBox1.Text = name;
            bunifuTextBox2.Text = Convert.ToString(cal);
            this.type_foodTableAdapter.Fill(this.foodDataSet.Type_food);
            this.picturesTableAdapter.Fill(this.foodDataSet.Pictures);
            comboBox2.Text = type;
            comboBox1.SelectedItem = image;
            comboBox1.SelectedValue = image;
        }

        public Change_admin_food(string name_, int cal_, string type_, int image_)
        {
            InitializeComponent();
            name = name_;
            cal = cal_;
            type = type_;
            image = image_;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Add_pictures f = new Add_pictures();
            f.Owner = this;
            f.ShowDialog();
            this.picturesTableAdapter.Fill(this.foodDataSet.Pictures);
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            int id = (int)comboBox2.SelectedValue;
            int id2 = (int)comboBox1.SelectedValue;
            admin_food main = this.Owner as admin_food;
            if (main != null)
            {
                main.change_food(bunifuTextBox1.Text, Convert.ToInt32(bunifuTextBox2.Text), id2, id);
            }
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
