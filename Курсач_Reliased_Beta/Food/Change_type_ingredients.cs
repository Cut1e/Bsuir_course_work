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
    public partial class Change_type_ingredients : Form
    {
        string type;
        public Change_type_ingredients(string type_)
        {
            InitializeComponent();
            type = type_;
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            change();
        }
        private void change()
        {
            type_ingredients main = this.Owner as type_ingredients;
            if(main != null)
            {
                main.change_type_ingredients(bunifuTextBox1.Text);
            }
        }

        private void Change_type_ingredients_Load(object sender, EventArgs e)
        {
            bunifuTextBox1.Text = type;
        }
    }
}
