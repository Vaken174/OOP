using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            if (e.Button == MouseButtons.Left)
            {
                string coordinates = $"X: {e.X}, Y: {e.Y}";
                g.DrawString(coordinates,new Font("Arial",10),Brushes.White, e.X,e.Y);
            }
            else if(e.Button == MouseButtons.Right)
            {
                MessageBox.Show("Не жми!", "Зачем нажал?");
            }
            else
                g.Clear(BackColor);
        }
    }
}
