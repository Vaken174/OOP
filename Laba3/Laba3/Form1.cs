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
        private bool isDrawing = false;
        private Rectangle currentRect;
        private List<Figure> figures = new List<Figure>();
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                currentRect = new Rectangle(e.Location, e.Location);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                // Обновляем конечную точку
                currentRect = new Rectangle(currentRect.FirstPoin, e.Location);
                this.Invalidate(); // Перерисовываем форму
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                isDrawing = false;
                figures.Add(currentRect); // Добавляем в коллекцию
                this.Invalidate();       // Перерисовываем
            }
            figures.Add(currentRect);
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Рисуем все сохранённые фигуры
            foreach (Figure figure in figures)
            {
                figure.Draw(e.Graphics);
            }

            // Рисуем текущий прямоугольник (если он есть)
            if (isDrawing && currentRect != null)
            {
                currentRect.DrawDash(e.Graphics);
            }
        }
    }


}
