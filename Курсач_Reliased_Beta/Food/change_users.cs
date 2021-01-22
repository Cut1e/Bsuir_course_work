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
    public partial class change_users : Form
    {
        string login, namee, password, word,accesss;
        int access;

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
             if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox3.Text == "" || bunifuTextBox4.Text == "")
            {
                MessageBox.Show("Не корректно введены данные", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                change_user();
        }
        private void change_user()
        {
            int id = (int)comboBox2.SelectedValue;
            users main = this.Owner as users;
            if(main!=null)
            {
                main.change_users(bunifuTextBox1.Text, bunifuTextBox2.Text, bunifuTextBox3.Text, bunifuTextBox4.Text, id);
            }
        }
        public change_users(string login_, string namee_, string password_, string word_, string access__, int access_)
        {
            InitializeComponent();
            login = login_;
            namee = namee_;
            password = password_;
            word = word_;
            accesss = access__;
            access = access_;
        }

        private void change_users_Load(object sender, EventArgs e)
        {
            if(access==2)
            {
                comboBox2.Enabled = false;
            }
            this.access_rightsTableAdapter.Fill(foodDataSet.access_rights);
            comboBox2.Text = accesss;
            bunifuTextBox1.Text = login;
            bunifuTextBox2.Text = namee;
            bunifuTextBox3.Text = password;
            bunifuTextBox4.Text = word;
        }
    }
}
