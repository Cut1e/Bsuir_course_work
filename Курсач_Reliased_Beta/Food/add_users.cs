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
    public partial class add_users : Form
    {
        int access;
        public add_users(int access_)
        {
            InitializeComponent();
            access = access_;
        }
        private void add_user_()
        {
            int id = (int)comboBox2.SelectedValue;
            users main = this.Owner as users;
            if(main!=null)
            {
                main.add_user(bunifuTextBox1.Text, bunifuTextBox2.Text, bunifuTextBox3.Text, bunifuTextBox4.Text, id,bunifuTextBox1.Text);
            }
        }
        private void add_users_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodDataSet.access_rights' table. You can move, or remove it, as needed.
            this.access_rightsTableAdapter.Fill(this.foodDataSet.access_rights);
            if(access==2)
            {
                comboBox2.Enabled = false;
            }

        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox3.Text == "" || bunifuTextBox4.Text == ""  )
            {
                MessageBox.Show("Не корректно введены данные", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                add_user_();
        }
    }
}
