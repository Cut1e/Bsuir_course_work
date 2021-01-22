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
    public partial class Change_type_food : Form
    {
        string type;
        public Change_type_food(string type_)
        {
            InitializeComponent();
            type = type_;
        }
        private void change()
        {
            type_food main = this.Owner as type_food;
            if(main!=null)
            {
                main.change_type_food(bunifuTextBox1.Text);
            }
        }
        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            change();
        }

        private void Change_type_food_Load(object sender, EventArgs e)
        {
            bunifuTextBox1.Text = type;
        }
    }
}
