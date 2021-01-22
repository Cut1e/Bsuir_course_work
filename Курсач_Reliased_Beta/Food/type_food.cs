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
    public partial class type_food : Form
    {
        public type_food()
        {
            InitializeComponent();
        }

        private void type_food_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodDataSet.Type_food' table. You can move, or remove it, as needed.
            this.type_foodTableAdapter.Fill(this.foodDataSet.Type_food);

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            this.typefoodBindingSource.Filter = null;
            bunifuTextBox1.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = bunifuDataGridView1.RowCount.ToString();
        }
        private void delete_type_food()
        {
            this.type_foodTableAdapter.DeleteQuery(Convert.ToInt32(bunifuDataGridView1.SelectedCells[0].Value));
            this.type_foodTableAdapter.Fill(this.foodDataSet.Type_food);
        }
        private void update_type_food()
        {
            this.type_foodTableAdapter.Fill(this.foodDataSet.Type_food);
        }
        public void add_type_food(string name_type)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите добавить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.type_foodTableAdapter.InsertQuery(name_type);
                    this.type_foodTableAdapter.Fill(this.foodDataSet.Type_food);
                    MessageBox.Show("Запись успешно добавлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void change_type_food(string name_type)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите изменить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int i = bunifuDataGridView1.SelectedCells[1].RowIndex;
                    this.type_foodTableAdapter.UpdateQuery(name_type, Convert.ToInt32(bunifuDataGridView1.SelectedCells[0].Value));
                    this.type_foodTableAdapter.Fill(this.foodDataSet.Type_food);
                    bunifuDataGridView1.CurrentCell = bunifuDataGridView1.Rows[i].Cells[1];
                    MessageBox.Show("Запись успешно изменена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            try
            {
                this.typefoodBindingSource.Filter = "[name_type_food] LIKE'" + bunifuTextBox1.Text + "%'";
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
                    delete_type_food();
                    MessageBox.Show("Запись успешно удалена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                update_type_food();
                MessageBox.Show("Таблица успешно обновлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Add_type_food f = new Add_type_food();
            f.Owner = this;
            f.ShowDialog();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            var type_food = (string)bunifuDataGridView1.SelectedCells[1].Value;
            Change_type_food f = new Change_type_food(type_food);
            f.Owner = this;
            f.ShowDialog();
        }
    }
}
