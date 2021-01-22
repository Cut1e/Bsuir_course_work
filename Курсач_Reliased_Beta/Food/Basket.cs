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
    public partial class Basket : Form
    {
        string user_login;
        public Basket()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = bunifuDataGridView1.RowCount.ToString();
        }

        private void Basket_Load(object sender, EventArgs e)
        {
            this.basketTableAdapter.Fill(this.foodDataSet.Basket, Convert.ToInt32(comboBox1.SelectedValue));
            // TODO: This line of code loads data into the 'foodDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.foodDataSet.Users);

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            this.basketBindingSource.Filter = null;
            bunifuTextBox1.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.basketTableAdapter.Fill(this.foodDataSet.Basket, Convert.ToInt32(comboBox1.SelectedValue));
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
                this.basketBindingSource.Filter = "[name] LIKE'" + bunifuTextBox1.Text + "%' or [name_type] LIKE'" + bunifuTextBox1.Text + "%'";
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void check(int kolvo)
        {
            int i = bunifuDataGridView1.SelectedCells[2].RowIndex;
            if (kolvo == 1)
            {
                this.basketTableAdapter.DeleteQuery(Convert.ToInt32(bunifuDataGridView1.SelectedCells[0].Value));
                this.basketTableAdapter.Fill(this.foodDataSet.Basket, Convert.ToInt32(comboBox1.SelectedValue));
                //if (bunifuDataGridView1.CurrentCell != null)
                //    bunifuDataGridView1.CurrentCell = bunifuDataGridView1.Rows[i].Cells[2];
            }
            if (kolvo > 1)
            {
                bunifuDataGridView1.SelectedCells[6].Value = Convert.ToInt32(bunifuDataGridView1.SelectedCells[6].Value) - 1;
                this.basketTableAdapter.UpdateQuantity(Convert.ToInt32(bunifuDataGridView1.SelectedCells[6].Value), Convert.ToInt32(bunifuDataGridView1.SelectedCells[0].Value));
                this.basketTableAdapter.Fill(this.foodDataSet.Basket, Convert.ToInt32(comboBox1.SelectedValue));
                //if (bunifuDataGridView1.CurrentCell != null)
                //    bunifuDataGridView1.CurrentCell = bunifuDataGridView1.Rows[i].Cells[2];
            }
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите удалить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    check(Convert.ToInt32(bunifuDataGridView1.SelectedCells[6].Value));
                    MessageBox.Show("Запись успешно удалена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Basket_Activated(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                this.basketTableAdapter.Fill(this.foodDataSet.Basket, Convert.ToInt32(comboBox1.SelectedValue));
                MessageBox.Show("Таблица успешно обновлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
