using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food
{
    public partial class Change_ingredients : Form
    {
        string name, type;
        int cal, image;
        public Change_ingredients(string name_, int cal_, string type_, int image_)
        {
            InitializeComponent();
            name = name_;
            cal = cal_;
            type = type_;
            image = image_;
        }

        private void Change_ingredients_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodDataSet.Pictures' table. You can move, or remove it, as needed.
            this.picturesTableAdapter.Fill(this.foodDataSet.Pictures);
            // TODO: This line of code loads data into the 'foodDataSet.Type_ingredients' table. You can move, or remove it, as needed.
            this.type_ingredientsTableAdapter.Fill(this.foodDataSet.Type_ingredients);
            bunifuTextBox1.Text = name;
            bunifuTextBox2.Text = Convert.ToString(cal);
            comboBox2.Text = type;
            comboBox1.SelectedItem = image;
            comboBox1.SelectedValue = image;

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
            Ingredients main = this.Owner as Ingredients;
            if (main != null)
            {
                main.change_ingredients(bunifuTextBox1.Text, Convert.ToInt32(bunifuTextBox2.Text), id2, id);
            }
        }
    }
}
