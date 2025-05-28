using System.Drawing;

namespace Laba3
{
    public abstract class Figure
    {
        public Point FirstPoin;
        public Point LastPoin;

        public Figure(Point p1, Point p2)
        {
            FirstPoin = p1; LastPoin = p2;

        }

        public abstract void Draw(Graphics g);
        public abstract void DrawDash(Graphics g);
        public abstract void Hide(Graphics g);
        public void NormalizeCoordinates(ref int x1, ref int y1, ref int x2, ref int y2)
        {
            if (x1 > x2) { int tmp = x1; x1 = x2; x2 = tmp; }
            if (y1 > y2) { int tmp = y1; y1 = y2; y2 = tmp; }
        }
    }


}
