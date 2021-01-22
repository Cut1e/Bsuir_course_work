using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Food
{
    public partial class admin_food : Form
    {
        public admin_food()
        {
            InitializeComponent();
        }

        private void admin_food_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodDataSet.Food' table. You can move, or remove it, as needed.
            this.foodTableAdapter.Fill(this.foodDataSet.Food);
            }
        private void delete_food()
        {
            this.foodTableAdapter.DeleteQuery((int)bunifuDataGridView1.SelectedCells[0].Value);
            this.foodTableAdapter.Fill(this.foodDataSet.Food);
        }
        private void update_food()
        {
            this.foodTableAdapter.Fill(this.foodDataSet.Food);
        }
        public void add_food(string name, int cal, int picture, int type)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите добавить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.foodTableAdapter.InsertQuery(name, cal, picture, type);
                    this.foodTableAdapter.Fill(this.foodDataSet.Food);
                    MessageBox.Show("Запись успешно добавлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void change_food(string name, int cal, int picture, int type)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите изменить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int i = bunifuDataGridView1.SelectedCells[2].RowIndex;
                    this.foodTableAdapter.UpdateQuery(name, cal, picture, type, (int)bunifuDataGridView1.SelectedCells[0].Value);
                    this.foodTableAdapter.Fill(this.foodDataSet.Food);
                    bunifuDataGridView1.CurrentCell = bunifuDataGridView1.Rows[i].Cells[2];
                    MessageBox.Show("Запись успешно изменена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = bunifuDataGridView1.RowCount.ToString();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            this.foodBindingSource.Filter = null;
            bunifuTextBox1.Text = "";
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                update_food();
                MessageBox.Show("Таблица успешно обновлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите удалить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    delete_food();
                    MessageBox.Show("Запись успешно удалена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Add_admin_food f = new Add_admin_food();
            f.Owner = this;
            f.ShowDialog();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            var namee = (string)bunifuDataGridView1.SelectedCells[1].Value;
            var cal = Convert.ToInt32(bunifuDataGridView1.SelectedCells[2].Value);
            var image = Convert.ToInt32(bunifuDataGridView1.SelectedCells[3].Value);
            var type = (string)bunifuDataGridView1.SelectedCells[5].Value;
            Change_admin_food f = new Change_admin_food(namee,cal,type,image);
            f.Owner = this;
            f.ShowDialog();
        }

        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            try
            {
                this.foodBindingSource.Filter = "[name_food] LIKE'" + bunifuTextBox1.Text + "%' or [name_type_food] LIKE'" + bunifuTextBox1.Text + "%'";
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
