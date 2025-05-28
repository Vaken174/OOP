using System.Drawing;

namespace Laba3
{
    public abstract class Figure
    {
        public Point FirstPoin;//х у начальной точки
        public Point LastPoin;//х у конечной точки

        public Figure(Point p1, Point p2)//вход р1 р2
        {
            FirstPoin = p1; LastPoin = p2;//инициализурует FirstPoin LastPoin

        }
        //abstract методы без реализации потому что должны быть+воид не возвращает значение
        public abstract void Draw(Graphics g);//сплошная линия
        public abstract void DrawDash(Graphics g);//пунктирная
        public abstract void Hide(Graphics g);//ластик
        public void NormalizeCoordinates(ref int x1, ref int y1, ref int x2, ref int y2)//реф это ссылка+изменения сохраняются
        {
            if (x1 > x2) { int tmp = x1; x1 = x2; x2 = tmp; }//если больше то меняются местами
            if (y1 > y2) { int tmp = y1; y1 = y2; y2 = tmp; }//тоже самое
        }
    }


}
