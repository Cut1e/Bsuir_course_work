using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Food
{
    public partial class Add_pictures : Form
    {
        public Add_pictures()
        {
            InitializeComponent();
        }
        string filenamee = " ";
        byte[] imageData;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                filenamee = openFileDialog1.FileName;
                using (System.IO.FileStream fs = new System.IO.FileStream(filenamee, FileMode.Open))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, imageData.Length);

                }
                Bitmap image = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = image;
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void add_picture(string title, byte[] image)
        {
            this.picturesTableAdapter.InsertQuery(image, title);
            this.picturesTableAdapter.Fill(this.foodDataSet.Pictures);
        }
        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите добавить выбранную запись?", "Внмание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    add_picture(bunifuTextBox1.Text, imageData);
                    pictures main = this.Owner as pictures;
                    if (main != null)
                    {
                        main.update_picture();
                    }
                    MessageBox.Show("Запись успешно добавлена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Упс..Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
