using System;
using SwinGameSDK;

namespace ShapeDrawing
{
    public class Line : Shape
    {
        private int _length;

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }

        public Line(Color shapeColor, int x, int y, int length) : base (shapeColor)
        {
            X = x;
            Y = y;
            _length = length;
        }

        public Line() : this (Color.Blue, 0, 0, 50) { }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SwinGame.DrawLine(ShapeColor, X, Y, X + _length, Y);
        }

        public override void DrawOutline()
        {
            for (int i = 0; i < _length; i++)
            {
                SwinGame.FillCircle(Color.Black, X + i, Y, 1);
            }
        }

        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointOnLine(pt, X, Y, X + _length, Y);
        }
    }
}