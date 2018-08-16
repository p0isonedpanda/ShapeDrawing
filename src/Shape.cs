using System;
using SwinGameSDK;

namespace ShapeDrawing
{
    class Shape
    {
        private Color _shapeColor;
        private float _x;
        private float _y;
        private int _width;
        private int _height;
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

        public Shape(Color shapeColor, float x, float y, int width, int height)
        {
            _shapeColor = shapeColor;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _selected = false;
        }

        public Shape() : this (Color.Green, 0, 0, 100, 100) { }

        public void Draw()
        {
            SwinGame.FillRectangle(_shapeColor, _x, _y, _width, _height);
            if (_selected)
            {
                SwinGame.DrawRectangle(Color.Black, _x, _y, _width, _height);
                SwinGame.DrawRectangle(Color.Black, _x - 1, _y - 1, _width + 2, _height + 2);
                SwinGame.DrawRectangle(Color.Black, _x - 2, _y - 2, _width + 4, _height + 4);
            }
        }

        public bool IsAt(Point2D pt)
        {
            return SwinGame.PointInRect(pt, _x, _y, _width, _height);
        }
    }
}