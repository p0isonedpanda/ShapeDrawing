using System;
using SwinGameSDK;

namespace ShapeDrawing
{
    public class Rectangle : Shape
    {
        private int _width;
        private int _height;

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public Rectangle(Color shapeColor, int x, int y, int width, int height) : base (shapeColor)
        {
            X = x;
            Y = y;
            _width = width;
            _height = height;
        }

        public Rectangle() : this (Color.Green, 0, 0, 50, 50) { }

        public override void Draw()
        {
            SwinGame.FillRectangle(ShapeColor, X, Y, _width, _height);
            if (Selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            if (Selected)
            {
                SwinGame.DrawRectangle(Color.Black, X, Y, _width, _height);
                SwinGame.DrawRectangle(Color.Black, X - 1, Y - 1, _width + 2, _height + 2);
                SwinGame.DrawRectangle(Color.Black, X - 2, Y - 2, _width + 4, _height + 4);
            }
        }

        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointInRect(pt, X, Y, _width, _height);
        }
    }
}