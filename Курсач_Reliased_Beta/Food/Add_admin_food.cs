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
    public partial class Add_admin_food : Form
    {
        public Add_admin_food()
        {
            InitializeComponent();
        }

        private void Add_admin_food_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodDataSet.Pictures' table. You can move, or remove it, as needed.
            this.picturesTableAdapter.Fill(this.foodDataSet.Pictures);
            // TODO: This line of code loads data into the 'foodDataSet.Type_food' table. You can move, or remove it, as needed.
            this.type_foodTableAdapter.Fill(this.foodDataSet.Type_food);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Add_pictures f = new Add_pictures();
            f.Owner = this;
            f.ShowDialog();
            this.picturesTableAdapter.Fill(this.foodDataSet.Pictures);
        }
        public void add()
        {
            int id = (int)comboBox2.SelectedValue;
            int id2 = (int)comboBox1.SelectedValue;
            admin_food main = this.Owner as admin_food;
            if (main != null)
            {
                main.add_food(bunifuTextBox1.Text,Convert.ToInt32(bunifuTextBox2.Text),id2,id);
            }
        }
        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            add();
        }
    }
}
