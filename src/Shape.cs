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

        public Shape()
        {
            _shapeColor = Color.Green;
            _x = 0;
            _y = 0;
            _width = 100;
            _height = 100;
        }

        public void Draw()
        {
            SwinGame.FillRectangle(_shapeColor, _x, _y, _width, _height);
        }

        public bool IsAt(Point2D pt)
        {
            return SwinGame.PointInRect(pt, _x, _y, _width, _height);
        }
    }
}