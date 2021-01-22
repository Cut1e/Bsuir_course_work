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
    public partial class Add_type_food : Form
    {
        public Add_type_food()
        {
            InitializeComponent();
        }
        private void add()
        {
            type_food main = this.Owner as type_food;
            if (main != null)
            {
                main.add_type_food(bunifuTextBox1.Text);
            }
        }
        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            add();
        }
    }
}
