using System;
using SwinGameSDK;

namespace ShapeDrawing
{
    public abstract class Shape
    {
        private Color _shapeColor;
        private float _x;
        private float _y;
        private bool _selected;

        public Color ShapeColor
        {
            get
            {
                return _shapeColor;
            }
            set
            {
                _shapeColor = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

        public Shape(Color shapeColor)
        {
            _shapeColor = shapeColor;
        }

        public Shape() : this (Color.Yellow) { }

        public abstract void Draw();
        public abstract void DrawOutline();
        public abstract bool IsAt(Point2D pt);
    }
}