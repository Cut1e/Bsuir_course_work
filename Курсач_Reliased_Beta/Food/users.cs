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
    public partial class users : Form
    {
        int access=0;
        public users(int acsess_)
        {
            access = acsess_;
            InitializeComponent();
        }

        private void users_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodDataSet.access_rights' table. You can move, or remove it, as needed.
            this.access_rightsTableAdapter.Fill(this.foodDataSet.access_rights);
            if (access==2)
            {
                this.usersTableAdapter.FillLowAdmin(foodDataSet.Users);
            }
            else
                if(access==3)
            {
                this.usersTableAdapter.FillMainAdmin(foodDataSet.Users);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = bunifuDataGridView1.RowCount.ToString();
        }
        private void delete_user()
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите удалить выбранного пользователя?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.usersTableAdapter.DeleteQuery((int)bunifuDataGridView1.SelectedCells[0].Value);
                    if (access == 3)
                    {
                        this.usersTableAdapter.FillMainAdmin(foodDataSet.Users);
                        MessageBox.Show("Операция прошла успешно!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (access == 2)
                    {
                        this.usersTableAdapter.FillLowAdmin(foodDataSet.Users);
                        MessageBox.Show("Операция прошла успешно!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void update_user()
        {
            try
            {
                this.usersTableAdapter.Fill(foodDataSet.Users);
                MessageBox.Show("Таблица пользователей обновлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
          delete_user();
            
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            update_user();
        }
        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            try
            {
                this.usersBindingSource.Filter = "[user_secret_word] LIKE '" + bunifuTextBox1.Text + "%' or [descriptioon] LIKE'" + bunifuTextBox1.Text + "%' or [user_password] LIKE'" + bunifuTextBox1.Text + "%' or [user_namee] LIKE'" + bunifuTextBox1.Text + "%' or [user_login] LIKE'" + bunifuTextBox1.Text + "%'";
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            this.usersBindingSource.Filter = null;
            bunifuTextBox1.Text = "";
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            this.usersBindingSource.Filter = null;
            bunifuTextBox1.Text = "";
        }

        public void change_users(string login, string name, string password, string word, int access_)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите изменить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int i = bunifuDataGridView1.SelectedCells[6].RowIndex;
                    if (access == 3)
                    {
                        this.usersTableAdapter.UpdateUsers(login, name, password, word, access_, (int)bunifuDataGridView1.SelectedCells[0].Value);
                        this.usersTableAdapter.FillMainAdmin(foodDataSet.Users);
                        bunifuDataGridView1.CurrentCell = bunifuDataGridView1.Rows[i].Cells[6];
                        MessageBox.Show("Операция прошла успешно!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (access == 2)
                    {
                        this.usersTableAdapter.UpdateUsers(login, name, password, word, access_, (int)bunifuDataGridView1.SelectedCells[0].Value);
                        this.usersTableAdapter.FillLowAdmin(foodDataSet.Users);
                        bunifuDataGridView1.CurrentCell = bunifuDataGridView1.Rows[i].Cells[6];
                        MessageBox.Show("Таблица пользователей обновлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuDataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
        public void add_user(string login, string name,string password,string word, int access_, string log_test)
        {
            try
            {
                for (int i = 0; i < bunifuDataGridView1.RowCount; i++)
                    if (log_test == Convert.ToString(bunifuDataGridView1.Rows[i].Cells[1].Value))
                    {
                        MessageBox.Show("Такой логин уже существует", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                if (MessageBox.Show("Вы уверены что хотите добавить выбранную запись?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (access == 3)
                    {
                        this.usersTableAdapter.InsertForMainAdmin(login, name, password, word, access_);
                        this.usersTableAdapter.FillMainAdmin(foodDataSet.Users);
                        MessageBox.Show("Запись добавлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if
                    (access == 2)
                    {
                        this.usersTableAdapter.InsertQuery(login, name, password, word);
                        this.usersTableAdapter.FillLowAdmin(foodDataSet.Users);
                        MessageBox.Show("Запись добавлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            add_users f = new add_users(access);
            f.Owner = this;
            f.ShowDialog();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            var login = (string)bunifuDataGridView1.SelectedCells[1].Value;
            var namee = (string)bunifuDataGridView1.SelectedCells[2].Value;
            var password = (string)bunifuDataGridView1.SelectedCells[3].Value;
            var word = (string)bunifuDataGridView1.SelectedCells[4].Value;
            var access_ = Convert.ToString(bunifuDataGridView1.SelectedCells[6].Value);
            change_users f = new change_users(login,namee,password,word,access_, access);
            f.Owner = this;
            f.ShowDialog();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
