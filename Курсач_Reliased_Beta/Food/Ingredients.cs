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
    public partial class Ingredients : Form
    {
        public Ingredients()
        {
            InitializeComponent();
        }

        private void Ingredients_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodDataSet.Ingredients' table. You can move, or remove it, as needed.
            this.ingredientsTableAdapter.Fill(this.foodDataSet.Ingredients);

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            this.ingredientsBindingSource.Filter = null;
            bunifuTextBox1.Text = "";
        }
        private void delete_ingredients()
        {
            this.ingredientsTableAdapter.DeleteQuery(Convert.ToInt32(bunifuDataGridView1.SelectedCells[0].Value));
            this.ingredientsTableAdapter.Fill(this.foodDataSet.Ingredients);
        }
        private void update_ingredients()
        {
            this.ingredientsTableAdapter.Fill(this.foodDataSet.Ingredients);
        }
        public void add_ingredietns(string name, int cal, int id_picture, int id_type)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите добавить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.ingredientsTableAdapter.InsertQuery(name, cal, id_picture, id_type);
                    this.ingredientsTableAdapter.Fill(this.foodDataSet.Ingredients);
                    MessageBox.Show("Запись успешно добавлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void change_ingredients(string name, int cal, int id_picture, int id_type)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите изменить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int i = bunifuDataGridView1.SelectedCells[2].RowIndex;
                    this.ingredientsTableAdapter.UpdateQuery(name, cal, id_picture, id_type, Convert.ToInt32(bunifuDataGridView1.SelectedCells[0].Value));
                    this.ingredientsTableAdapter.Fill(this.foodDataSet.Ingredients);
                    bunifuDataGridView1.CurrentCell = bunifuDataGridView1.Rows[i].Cells[2];
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
                this.ingredientsBindingSource.Filter = "[name_ingreients] LIKE'" + bunifuTextBox1.Text + "%' or [name_type_ingredients] LIKE'" + bunifuTextBox1.Text + "%'";
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Add_ingredients f = new Add_ingredients();
            f.Owner = this;
            f.ShowDialog();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            var namee = (string)bunifuDataGridView1.SelectedCells[1].Value;
            var cal = Convert.ToInt32(bunifuDataGridView1.SelectedCells[2].Value);
            var image = Convert.ToInt32(bunifuDataGridView1.SelectedCells[3].Value);
            var type = (string)bunifuDataGridView1.SelectedCells[5].Value;
            Change_ingredients f = new Change_ingredients(namee, cal, type, image);
            f.Owner = this;
            f.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = bunifuDataGridView1.RowCount.ToString();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите удалить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    delete_ingredients();
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

                update_ingredients();
                MessageBox.Show("Таблица успешно обновлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
