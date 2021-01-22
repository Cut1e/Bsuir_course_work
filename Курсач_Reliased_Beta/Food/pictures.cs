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
    public partial class pictures : Form
    {
        public pictures()
        {
            InitializeComponent();
        }

        private void pictures_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodDataSet.Pictures' table. You can move, or remove it, as needed.
            this.picturesTableAdapter.Fill(this.foodDataSet.Pictures);

        }

        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            try
            {
                this.picturesBindingSource.Filter = "[title_pictures] LIKE'" + bunifuTextBox1.Text + "%'";
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            this.picturesBindingSource.Filter = null;
            bunifuTextBox1.Text = "";
        }
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        private void delete_picture()
        {
            this.picturesTableAdapter.DeleteQuery(Convert.ToInt32(bunifuDataGridView1.SelectedCells[0].Value),ImageToByte(pictureBox1.Image));
            this.picturesTableAdapter.Fill(this.foodDataSet.Pictures);
        }    
        public void update_picture()
        {
            this.picturesTableAdapter.Fill(this.foodDataSet.Pictures);
        }
        public void change_picture(string title, byte[] image)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите изменить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int i = bunifuDataGridView1.SelectedCells[2].RowIndex;
                    this.picturesTableAdapter.UpdateQuery(image, title, (int)bunifuDataGridView1.SelectedCells[0].Value);
                    this.picturesTableAdapter.Fill(this.foodDataSet.Pictures);
                    bunifuDataGridView1.CurrentCell = bunifuDataGridView1.Rows[i].Cells[2];
                    MessageBox.Show("Запись успешно изменена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
 
            string title=(string)bunifuDataGridView1.SelectedCells[2].Value;
            Bitmap image=(Bitmap)pictureBox1.Image;
            Change_pictures f = new Change_pictures(title, image);
            f.Owner=this;
            f.ShowDialog();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                update_picture();
                MessageBox.Show("Таблица успешно обновлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Add_pictures f = new Add_pictures();
            f.Owner = this;
            f.ShowDialog();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите удалить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    delete_picture();
                    MessageBox.Show("Запись успешно удалена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
