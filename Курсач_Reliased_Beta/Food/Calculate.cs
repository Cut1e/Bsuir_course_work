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
    public partial class Calculate : Form
    {
        double sum;
        public Calculate(double sum_)
        {
            InitializeComponent();
            sum = sum_;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users_basket main = this.Owner as Users_basket;
            if(main!=null)
            {
               
            }
        }

        private void Calculate_Load(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(sum);
            Users_basket main = this.Owner as Users_basket;
            if (main != null)
            {
               label13.Text=Convert.ToString("Чтобы потратить "+sum+" калорий\nнужно поплавать:\n"+ main.Swim()+" минут(ы)");
                label14.Text = Convert.ToString("Чтобы потратить " + sum + " калорий\nнужно заниматься\nйогой: " + main.Yoga() + " минут(ы)");
                label15.Text = Convert.ToString("Чтобы потратить " + sum + " калорий\nнужно быстро ходить\n " + main.Fast_steps() + " минут(ы)");
                label16.Text = Convert.ToString("Чтобы потратить " + sum + " калорий\nнужно бегать\n " + main.run() + " минут(ы)");
                label17.Text = Convert.ToString("Чтобы потратить " + sum + " калорий\nнужно прыгать на \nскакалке " + main.Skokalka() + " раз(а)");
                label18.Text = Convert.ToString("Чтобы потратить " + sum + " калорий\nнужно приседать\n " + main.Prised() + " минут(ы)");
                label19.Text = Convert.ToString("Чтобы потратить " + sum + " калорий\nнужно использовать\nканаты " + main.Kanati() + " минут(ы)");
                label20.Text = Convert.ToString("Чтобы потратить " + sum + " калорий\nнужно использовать\nнирю " + main.Girya() + " минут(ы)");
                label21.Text = Convert.ToString("Чтобы потратить " + sum + " калорий\nнужно ехать на\nвелосипеде " + main.Bicycle() + " минут(ы)");
                label22.Text = Convert.ToString("Чтобы потратить " + sum + " калорий\nнужно выполнить\nпресс " + main.press() + " раз(а)");
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

           
        

    }

        
    }
}
