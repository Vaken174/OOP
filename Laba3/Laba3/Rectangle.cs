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
    public class Rectangle : Figure
    {
        public Rectangle(Point p1, Point p2) : base(p1, p2) { }

        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, 1))
            {
                int x1 = FirstPoin.X, y1 = FirstPoin.Y;
                int x2 = LastPoin.X, y2 = LastPoin.Y;
                NormalizeCoordinates(ref x1, ref y1, ref x2, ref y2);
                g.DrawRectangle(pen, x1, y1, x2 - x1, y2 - y1);
            }
        }

        public override void DrawDash(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, 1) { DashStyle = DashStyle.Dash })
            {
                int x1 = FirstPoin.X, y1 = FirstPoin.Y;
                int x2 = LastPoin.X, y2 = LastPoin.Y;
                NormalizeCoordinates(ref x1, ref y1, ref x2, ref y2);
                g.DrawRectangle(pen, x1, y1, x2 - x1, y2 - y1);
            }
        }

        public override void Hide(Graphics g)
        {
            using (Pen pen = new Pen(Color.White, 1))
            {
                int x1 = FirstPoin.X, y1 = FirstPoin.Y;
                int x2 = LastPoin.X, y2 = LastPoin.Y;
                NormalizeCoordinates(ref x1, ref y1, ref x2, ref y2);
                g.DrawRectangle(pen, x1, y1, x2 - x1, y2 - y1);
            }
        }
    }
}
