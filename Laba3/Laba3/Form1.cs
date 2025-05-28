using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool isDrawing = false;//рисуем или нет
        private Rectangle currentRect;//текущий прямоугольник
        private List<Figure> figures = new List<Figure>();//список прямоугольников
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;//рисуем
                currentRect = new Rectangle(e.Location, e.Location);//текущий прямоугольник= прямоугольник с 2 координатами
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                currentRect = new Rectangle(currentRect.FirstPoin, e.Location);//обновляем конечную точку, начальная остается
                this.Invalidate();//прорисовка формы
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                isDrawing = false;//больше не рисуем
                figures.Add(currentRect); //добавляем в коллекцию
                this.Invalidate();       //перерисовываем форму
            }
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure figure in figures)//рисуем все сохранённые фигуры
            {
                figure.Draw(e.Graphics);//для каждой фигуры метод дро
            }

            if (isDrawing && currentRect != null)//рисуем текущий прямоугольник (если он есть)
            {
                currentRect.DrawDash(e.Graphics);//рисуем пунктиром
            }
        }
    }


}
