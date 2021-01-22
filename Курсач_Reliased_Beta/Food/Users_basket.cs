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
    public partial class Users_basket : Form
    {
        string user_login;
        public Users_basket(string user_login_)
        {
            InitializeComponent();
            user_login = user_login_;
        }

        private void Users_basket_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodDataSet.Basket' table. You can move, or remove it, as needed.
            this.basketTableAdapter.Fill(this.foodDataSet.Basket, Convert.ToInt32(user_login));

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = bunifuDataGridView1.RowCount.ToString();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            this.basketBindingSource.Filter = null;
            bunifuTextBox1.Text = "";
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

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                this.basketTableAdapter.Fill(this.foodDataSet.Basket, Convert.ToInt32(user_login));
                MessageBox.Show("Таблица обновлена успешно!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    this.basketTableAdapter.Fill(this.foodDataSet.Basket, Convert.ToInt32(user_login));
                    //if(bunifuDataGridView1.CurrentCell!=null)
                    //bunifuDataGridView1.CurrentCell = bunifuDataGridView1.Rows[i].Cells[2];
                }
                if (kolvo > 1)
                {
                    bunifuDataGridView1.SelectedCells[6].Value = Convert.ToInt32(bunifuDataGridView1.SelectedCells[6].Value) - 1;
                    this.basketTableAdapter.UpdateQuantity(Convert.ToInt32(bunifuDataGridView1.SelectedCells[6].Value), Convert.ToInt32(bunifuDataGridView1.SelectedCells[0].Value));
                    this.basketTableAdapter.Fill(this.foodDataSet.Basket, Convert.ToInt32(user_login));
                    //if (bunifuDataGridView1.CurrentCell != null)
                    //    bunifuDataGridView1.CurrentCell = bunifuDataGridView1.Rows[i].Cells[2];
                }

        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите удалить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    check(Convert.ToInt32(bunifuDataGridView1.SelectedCells[6].Value));
                    MessageBox.Show("Операция прошла успешно!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        public double Swim()
        {
            double horS = 1;
            int swim = 800;
            int kal = 0, kol;
            double needSwim, sum=0;
            for (int i = 0; i < bunifuDataGridView1.RowCount; i++)
            {
                kol = Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[6].Value);
                kal += Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[2].Value) * kol;
            }
            sum += kal;
            needSwim = ((sum * horS) / swim) * 60.0;
            return Math.Round(needSwim, 1);

        }
        public double Yoga()
        {
            double horS = 1;
            int yoga = 175;
            int kal = 0, kol;
            double needSwim, sum = 0;
            for (int i = 0; i < bunifuDataGridView1.RowCount; i++)
            {
                kol = Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[6].Value);
                kal += Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[2].Value) * kol;
            }
            sum += kal;
             needSwim = ((sum * horS) / yoga) * 60.0;
            return Math.Round(needSwim, 1);



        }
        public double Fast_steps()
        {
            double horS = 1;
            int steps = 550;
            int kal = 0, kol;
            double needSwim, sum = 0;
            for (int i = 0; i < bunifuDataGridView1.RowCount; i++)
            {
                kol = Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[6].Value);
                kal += Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[2].Value) * kol;
            }
            sum += kal;
            needSwim = ((sum * horS) / steps) * 60.0;
            return Math.Round(needSwim, 1);

        }
        public double run()
        {
            double horS = 1;
            int run = 700;
            int kal = 0, kol;
            double needSwim, sum = 0;
            for (int i = 0; i < bunifuDataGridView1.RowCount; i++)
            {
                kol = Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[6].Value);
                kal += Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[2].Value) * kol;
            }
            sum += kal;
             needSwim = ((sum * horS) / run) * 60.0;
            return Math.Round(needSwim, 1);

        }
        public double Skokalka()
        {
            double horS = 100;
            int skok = 13;
            int kal = 0, kol;
            double needSwim, sum = 0;
            for (int i = 0; i < bunifuDataGridView1.RowCount; i++)
            {
                kol = Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[6].Value);
                kal += Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[2].Value) * kol;
            }
            sum += kal;
            needSwim = ((sum * horS) / skok);
            return Math.Round(needSwim, 1);

        }
        public double Prised()
        {
            double horS = 1;
            int Prised = 804;
            int kal = 0, kol;
            double needSwim, sum = 0;
            for (int i = 0; i < bunifuDataGridView1.RowCount; i++)
            {
                kol = Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[6].Value);
                kal += Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[2].Value) * kol;
            }
            sum += kal;
           needSwim = ((sum * horS) / Prised) * 60.0;
            return Math.Round(needSwim, 1);

        }
        public double Kanati()
        {
            double horS = 1;
            int Prised = 618;
            int kal = 0, kol;
            double needSwim, sum = 0;
            for (int i = 0; i < bunifuDataGridView1.RowCount; i++)
            {
                kol = Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[6].Value);
                kal += Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[2].Value) * kol;
            }
            sum += kal;
           needSwim = ((sum * horS) / Prised) * 60.0;
            return Math.Round(needSwim, 1);

        }
        public double Girya()
        {
            double horS = 1;
            int Prised = 1212;
            int kal = 0, kol;
            double needSwim, sum = 0;
            for (int i = 0; i < bunifuDataGridView1.RowCount; i++)
            {
                kol = Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[6].Value);
                kal += Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[2].Value) * kol;
            }
            sum += kal;
             needSwim = ((sum * horS) / Prised) * 60.0;
            return Math.Round(needSwim, 1);

        }
        public double Bicycle()
        {
            double horS = 1;
            int Prised = 2200;
            int kal = 0, kol;
            double needSwim, sum = 0;
            for (int i = 0; i < bunifuDataGridView1.RowCount; i++)
            {
                kol = Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[6].Value);
                kal += Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[2].Value) * kol;
            }
            sum += kal;
             needSwim = ((sum * horS) / Prised) * 60.0;
            return Math.Round(needSwim, 1);

        }
        public double press()
        {
            double horS = 100;
            int Prised = 20;
            int kal = 0, kol;
            double needSwim, sum = 0;
            for (int i = 0; i < bunifuDataGridView1.RowCount; i++)
            {
                kol = Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[6].Value);
                kal += Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[2].Value) * kol;
            }
            sum += kal;
             needSwim = ((sum * Prised) / horS);
            return Math.Round(needSwim, 1);

        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            int kal = 0, kol;
            double  sum = 0;
            for (int i = 0; i < bunifuDataGridView1.RowCount; i++)
            {
                kol = Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[6].Value);
                kal += Convert.ToInt32(bunifuDataGridView1.Rows[i].Cells[2].Value) * kol;
            }
            sum += kal;
            Calculate f = new Calculate(sum);
            f.Owner = this;
            f.ShowDialog();
        }
    }
}
