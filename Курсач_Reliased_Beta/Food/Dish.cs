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
    public partial class Dish : Form
    {
        string user_login;
        public Dish(string user_login_)
        {
            user_login = user_login_;
            InitializeComponent();
        }

        private void Dish_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodDataSet.Food' table. You can move, or remove it, as needed.
            this.foodTableAdapter.Fill(this.foodDataSet.Food);
            this.basketTableAdapter.Fill(this.foodDataSet.Basket, Convert.ToInt32(user_login));
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
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите добавить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    check(Convert.ToString(bunifuDataGridView1.SelectedCells[1].Value));
                    MessageBox.Show("Запись успешно добавлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
        private void check(string name)
        {
            
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        if (name == Convert.ToString(dataGridView1.Rows[i].Cells[1].Value))
                        {
                            dataGridView1.Rows[i].Cells[6].Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value) + 1;
                            this.basketTableAdapter.UpdateQuantity(Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value));
                            this.basketTableAdapter.Fill(this.foodDataSet.Basket, Convert.ToInt32(user_login));
                            return;
                        }
                    }
                    this.basketTableAdapter.InsertQuery(Convert.ToString(bunifuDataGridView1.SelectedCells[1].Value), Convert.ToInt32(bunifuDataGridView1.SelectedCells[2].Value), Convert.ToString(bunifuDataGridView1.SelectedCells[5].Value), ImageToByte(pictureBox1.Image), Convert.ToInt32(user_login));
                
        }
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                this.foodTableAdapter.Fill(this.foodDataSet.Food);
                MessageBox.Show("Таблица успешно обновлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
    }
    }

