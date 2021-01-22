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
    public partial class Login : Form
    {
        bool mnuExpanded = false;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private void move_form(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public Login()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
     
        }

        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            bunifuTransition1.HideSync(panel1);
            bunifuTransition2.ShowSync(panel2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(panel2);
            bunifuTransition1.ShowSync(panel1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bunifuTransition1.HideSync(panel1);
            bunifuTransition2.ShowSync(panel2);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(panel2);
            bunifuTransition1.ShowSync(panel1);
        }

        private void Login_Load(object sender, EventArgs e)
        { 
            this.usersTableAdapter.Fill(this.foodDataSet.Users);
            panel1.Visible = false;
            label10.Visible = false;
            bunifuMaterialTextbox7.Visible = false;
            //this.usersTableAdapter.EnterLogin(this.foodDataSet.Users);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bunifuTransition1.HideSync(panel1);
            bunifuTransition2.ShowSync(panel2);
        }

        private void enter_user()
        {
            int access =0;
            try
            {
                if (checkBox1.Checked == false)
                {
                    string name = bunifuMaterialTextbox1.Text;
                    string password = bunifuMaterialTextbox6.Text;
                    for (int i = 0; i < usersDataGridView.RowCount; i++)
                        if (name == Convert.ToString(usersDataGridView.Rows[i].Cells[0].Value) && password == Convert.ToString(usersDataGridView.Rows[i].Cells[2].Value))
                        {
                            access = 1;
                            if (access == Convert.ToInt32(usersDataGridView.Rows[i].Cells[4].Value))
                            {
                                MessageBox.Show("Добро пожаловать " + Convert.ToString(usersDataGridView.Rows[i].Cells[1].Value) + "!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                string user_name = Convert.ToString(usersDataGridView.Rows[i].Cells[1].Value);
                                string user_login = Convert.ToString(usersDataGridView.Rows[i].Cells[5].Value);
                                MainForm mform = new MainForm(user_name, user_login);
                                mform.Show();
                                this.Hide();
                                return;
                            }
                            else
                                access = 2;
                            if (2 == Convert.ToInt32(usersDataGridView.Rows[i].Cells[4].Value))
                            {
                                MessageBox.Show("Добро пожаловать " + Convert.ToString(usersDataGridView.Rows[i].Cells[1].Value) + "!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MainFormAdmin mformA = new MainFormAdmin(access);
                                mformA.Show();

                                this.Hide();
                                return;
                            }
                            else
                                access = 3;
                            if (3 == Convert.ToInt32(usersDataGridView.Rows[i].Cells[4].Value))
                            {
                                MessageBox.Show("Добро пожаловать " + Convert.ToString(usersDataGridView.Rows[i].Cells[1].Value) + "!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MainFormAdmin mformA = new MainFormAdmin(access);
                                mformA.Show();
                                this.Hide();
                                return;
                            }
                            else
                            {
                                continue;
                            }
                        }


                }
                if (checkBox1.Checked == true)
                {
                    string name = bunifuMaterialTextbox1.Text;
                    string password = bunifuMaterialTextbox7.Text;
                    for (int i = 0; i < usersDataGridView.RowCount; i++)
                        if (name == Convert.ToString(usersDataGridView.Rows[i].Cells[0].Value) && password == Convert.ToString(usersDataGridView.Rows[i].Cells[3].Value))
                        {
                            MessageBox.Show("Добро пожаловать " + Convert.ToString(usersDataGridView.Rows[i].Cells[1].Value) + "!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            string user_name = Convert.ToString(usersDataGridView.Rows[i].Cells[1].Value);
                            string user_login = Convert.ToString(usersDataGridView.Rows[i].Cells[5].Value);
                            MainForm mform = new MainForm(user_name, user_login);
                            mform.Show();
                            this.Hide();
                            return;
                        }
                        else
                        {
                            continue;
                        }
                }

                MessageBox.Show("Не правильный логин или пароль", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            enter_user();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(panel2);
            bunifuTransition1.ShowSync(panel1);
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.foodDataSet);

        }
        private void add_login()
        {
            try
            {
                if (test_login(bunifuMaterialTextbox2.Text, bunifuMaterialTextbox3.Text, bunifuMaterialTextbox4.Text, bunifuMaterialTextbox5.Text))
                {
                    this.usersTableAdapter.InsertQuery(bunifuMaterialTextbox2.Text, bunifuMaterialTextbox3.Text, bunifuMaterialTextbox4.Text, bunifuMaterialTextbox5.Text);
                    MessageBox.Show("Новый пользователь добавлен!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.usersTableAdapter.Fill(this.foodDataSet.Users);
                    bunifuMaterialTextbox2.Text = null;
                    bunifuMaterialTextbox2.Text = null;
                    bunifuMaterialTextbox3.Text = null;
                    bunifuMaterialTextbox4.Text = null;
                    bunifuMaterialTextbox5.Text = null;
                    bunifuMaterialTextbox2.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < usersDataGridView.RowCount; i++)
                if (bunifuMaterialTextbox2.Text == Convert.ToString(usersDataGridView.Rows[i].Cells[0].Value))
                {
                    MessageBox.Show("Такой логин уже существует", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                    add_login();

        }
        public bool test_login(string login, string name, string password, string Sword)
        {
         
            if (login=="")
            {
                MessageBox.Show("Не корректно введен логин", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (name== "")
            {
                MessageBox.Show("Не корректно введено имя пользователя", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(password== "")
            {
                MessageBox.Show("Не корректно введен пароль", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (Sword== "")
                {
                MessageBox.Show("Не корректно введено проверочное слово", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    
        private void bunifuFlatButton6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                label10.Visible = true;
                bunifuMaterialTextbox7.Visible = true;
                label8.Visible = false;
                bunifuMaterialTextbox6.Visible = false;
                checkBox1.Checked = true;
            }
            else
            {
                label10.Visible = false;
                bunifuMaterialTextbox7.Visible = false;
                label8.Visible = true;
                bunifuMaterialTextbox6.Visible = true;
                checkBox1.Checked = false;
            }
        }
          
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move_form(sender, e);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            move_form(sender, e);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            move_form(sender, e);
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            move_form(sender, e);
        }
    }
}
