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
    public partial class Add_type_ingredietns : Form
    {
        public Add_type_ingredietns()
        {
            InitializeComponent();
        }
        private void add()
        {
            type_ingredients main = this.Owner as type_ingredients;
            if(main!= null)
            {
                main.add_type_ingredients(bunifuTextBox1.Text);
            }
        }
        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            add();
        }
    }
}
