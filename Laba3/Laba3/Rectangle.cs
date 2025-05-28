using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    public class Rectangle : Figure//наследование от фигур
    {
        public Rectangle(Point p1, Point p2) : base(p1, p2) { }

        public override void Draw(Graphics g)//переопределение метода
        {
            using (Pen pen = new Pen(Color.Black, 1))//создание (типо линии) черным с 1 толщиной
            {
                int x1 = FirstPoin.X, y1 = FirstPoin.Y;//коорд 1 точки
                int x2 = LastPoin.X, y2 = LastPoin.Y;//коорд 2 точки
                NormalizeCoordinates(ref x1, ref y1, ref x2, ref y2);//нормализация(от переворотов)
                g.DrawRectangle(pen, x1, y1, x2 - x1, y2 - y1);//рисование прямоугольника с 4точками
            }
        }

        public override void DrawDash(Graphics g)//пунктирная линия
        {
            using (Pen pen = new Pen(Color.Black, 1) { DashStyle = DashStyle.Dash })//(типо линия)черный цвет 1 толщина
            {
                int x1 = FirstPoin.X, y1 = FirstPoin.Y;//1 коорд
                int x2 = LastPoin.X, y2 = LastPoin.Y;//2 коорд
                NormalizeCoordinates(ref x1, ref y1, ref x2, ref y2);//нормализация с сылками(изменения сохраняются)
                g.DrawRectangle(pen, x1, y1, x2 - x1, y2 - y1);//рисование пунктирного прямоугольника
            }
        }

        public override void Hide(Graphics g)
        {
            using (Pen pen = new Pen(Color.White, 1))//Color.White должен был быть this.BackColor но костыль из-за ошибки
            {
                int x1 = FirstPoin.X, y1 = FirstPoin.Y;//1 коорд
                int x2 = LastPoin.X, y2 = LastPoin.Y;//2 коорд
                NormalizeCoordinates(ref x1, ref y1, ref x2, ref y2);//нормализация с сылками(изменения сохраняются)
                g.DrawRectangle(pen, x1, y1, x2 - x1, y2 - y1);//рисование прямоугольника с цветом бэграунда
            }
        }
    }
}
