using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba2
{
    public partial class Form2 : Form
    {
        private bool isDrawing = false;//проверка на нажатие типо
        private Point startPoint;//начальная точка
        private Rectangle prevRect;//прошлый квадрат
        private Graphics g;//объект график
        public Form2()
        {
            InitializeComponent();
           
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            g = this.CreateGraphics();//инициализация график
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                startPoint = e.Location;//начальная точка
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            g = this.CreateGraphics();
            if (isDrawing)
            {

                Pen erasePen = new Pen(this.BackColor, 2);//объявление линии толщиной  2 и цветом беграунда
                g.DrawRectangle(erasePen, prevRect);//рисует прямоугольник по указанным координатам с переменной пэн


                Pen dashPen = new Pen(Color.Black, 2);//объявление линии толщиной  2 и цветом блэк
                dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;//настройка линии в пунктир а не сплошной

                int x1 = Math.Min(startPoint.X, e.X);// указываем конкретные коорды
                int y1 = Math.Min(startPoint.Y, e.Y);
                int x2 = Math.Max(startPoint.X, e.X);
                int y2 = Math.Max(startPoint.Y, e.Y);

                prevRect = Rectangle.FromLTRB(x1, y1, x2, y2);// указываем коорды в перменной
                g.DrawRectangle(dashPen, prevRect);//рисуем пунктиром + указанный прямоугольник
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            g = this.CreateGraphics();
            if (isDrawing && e.Button == MouseButtons.Left)// если русуем и если лкм
            {
                isDrawing = false;//закончили рисовать

                
                Pen erasePen = new Pen(this.BackColor, 2); //толщина и цвет
                g.DrawRectangle(erasePen, prevRect);//стираем пунктирный прямоугольник

                
                Pen solidPen = new Pen(Color.Black, 2);//толщина и цвет
                g.DrawRectangle(solidPen, prevRect);//рисуем сплошной прямоугольник
            }
        }
    }
}
