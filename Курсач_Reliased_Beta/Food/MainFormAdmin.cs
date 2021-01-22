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
    public partial class MainFormAdmin : Form
    {
        int access=0;
        public MainFormAdmin(int access_)
        {
            access = access_;
            InitializeComponent();
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

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            openChildFrom(new users(access));
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
                    panel1.Width = 190;
                    this.Focus();
                }
            }
            else
            {
                if (mnuExpanded)
                {
                    mnuExpanded = false;
                    panel1.Visible = false;
                    panel1.Width = 45;
                    bunifuTransition1.Show(panel1);
                    this.Focus();
                }
            }
        }

        private void MainFormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void MainFormAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            openChildFrom(new admin_food());
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            openChildFrom(new pictures());
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            openChildFrom(new type_food());
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            openChildFrom(new type_ingredients());
        }

        private void bunifuFlatButton1_Click_2(object sender, EventArgs e)
        {
            openChildFrom(new Ingredients());
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            openChildFrom(new Basket());
        }
    }
}
