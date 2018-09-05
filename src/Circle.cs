using System;
using System.IO;
using SwinGameSDK;

namespace ShapeDrawing
{
    public class Circle : Shape
    {
        private int _radius;

        public int Radius { get; set; }

        public Circle(Color shapeColor, int x, int y, int radius) : base (shapeColor)
        {
            X = x;
            Y = y;
            _radius = radius;
            ShapeColor = shapeColor;
        }

        public Circle() : this (Color.Purple, 0, 0, 50) { }

        public override void Draw()
        {
            SwinGame.FillCircle(ShapeColor, X, Y, _radius);
            if (Selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            SwinGame.DrawCircle(Color.Black, X, Y, _radius);
            SwinGame.DrawCircle(Color.Black, X, Y, _radius + 1);
            SwinGame.DrawCircle(Color.Black, X, Y, _radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointInCircle(pt, X, Y, _radius);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(_radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _radius = reader.ReadInteger();
        }
    }
}