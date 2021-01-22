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
    public partial class Change_pictures : Form
    {
        string title;
        Bitmap image;
        public Change_pictures(string title_, Bitmap image_)
        {
            InitializeComponent();
            title = title_;
            image = image_;
        }
        string filenamee = " ";
        byte[] imageData;
        private void Change_pictures_Load(object sender, EventArgs e)
        {
            bunifuTextBox1.Text = title;
            pictureBox1.Image = image;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            pictures main = this.Owner as pictures;
            if (main != null)
            {
                if(imageData!=null)
                main.change_picture(bunifuTextBox1.Text, imageData);
                else        
                main.change_picture(bunifuTextBox1.Text,ImageToByte(image));
            }
        }
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
