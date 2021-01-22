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
    public partial class type_ingredients : Form
    {
        public type_ingredients()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = bunifuDataGridView1.RowCount.ToString();
        }

        private void type_ingredients_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodDataSet.Type_ingredients' table. You can move, or remove it, as needed.
            this.type_ingredientsTableAdapter.Fill(this.foodDataSet.Type_ingredients);

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            this.typeingredientsBindingSource.Filter = null;
            bunifuTextBox1.Text = "";
        }
        private void delete_type_ingredients()
        {
            this.type_ingredientsTableAdapter.DeleteQuery(Convert.ToInt32(bunifuDataGridView1.SelectedCells[0].Value));
            this.type_ingredientsTableAdapter.Fill(this.foodDataSet.Type_ingredients);
        }
        private void update_type_ingredients()
        {
            this.type_ingredientsTableAdapter.Fill(this.foodDataSet.Type_ingredients);
        }
        public void add_type_ingredients(string type_name)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите добавить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.type_ingredientsTableAdapter.InsertQuery(type_name);
                    this.type_ingredientsTableAdapter.Fill(this.foodDataSet.Type_ingredients);
                    MessageBox.Show("Запись успешно добавлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void change_type_ingredients(string type_name)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите изменить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int i = bunifuDataGridView1.SelectedCells[1].RowIndex;
                    this.type_ingredientsTableAdapter.UpdateQuery(type_name, Convert.ToInt32(bunifuDataGridView1.SelectedCells[0].Value));
                    this.type_ingredientsTableAdapter.Fill(this.foodDataSet.Type_ingredients);
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
                this.typeingredientsBindingSource.Filter = "[name_type_ingredients] LIKE'" + bunifuTextBox1.Text + "%'";
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            var type = (string)bunifuDataGridView1.SelectedCells[1].Value;
            Change_type_ingredients f = new Change_type_ingredients(type);
            f.Owner = this;
            f.ShowDialog();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                update_type_ingredients();
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
                    delete_type_ingredients();
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
            Add_type_ingredietns f = new Add_type_ingredietns();
            f.Owner = this;
            f.ShowDialog();
        }
    }
}
