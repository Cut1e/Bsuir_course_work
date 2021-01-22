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
    public partial class MainForm : Form
    {
        string user_name,user_login;
        public MainForm(string user_name_, string user_login_)
        {
            InitializeComponent();
            this.KeyPreview = true;
            user_name = user_name_;
            user_login = user_login_;
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodDataSet.Users' table. You can move, or remove it, as needed.
            label7.Text = user_name;
    

        }
        
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        private Form activeFrom = null;
        private void openChildFrom(Form childForm)
        {
            if (activeFrom != null)
                activeFrom.Close();
            activeFrom = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }
        bool mnuExpanded = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!bunifuTransition1.IsCompleted) return;
            if (panel1.ClientRectangle.Contains(PointToClient(Control.MousePosition)))
            {
                if (!mnuExpanded)
                {
                    mnuExpanded = true;
                    panel1.Width = 195;
                    this.Focus();
                }
            }
            else
            {
                if (mnuExpanded)
                {
                    mnuExpanded = false;
                    panel1.Visible = false;
                    panel1.Width = 44;
                    bunifuTransition1.Show(panel1);
                    this.Focus();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            openChildFrom(new Dish(user_login));
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            openChildFrom(new Users_ingredients(user_login));
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            openChildFrom(new Users_basket(user_login));
        }
    }
}
