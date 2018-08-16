using System;
using System.Linq;
using SwinGameSDK;
using System.Collections.Generic;

namespace ShapeDrawing
{
    class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public Drawing() : this (Color.White) { }

        public List<Shape> SelectedShapes
        {
            get
            {
                return _shapes.Where(shape => shape.Selected).ToList();
            }
        }

        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }

        public Color Background
        {
            get
            {
                return _background;
            }

            set
            {
                _background = value;
            }
        }

        public void Draw()
        {
            SwinGame.ClearScreen(Color.White);
            foreach (Shape s in _shapes)
            {
                s.Draw();
            }
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                s.Selected = s.IsAt(pt);
            }
        }

        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        public void RemoveSelected()
        {
            foreach (Shape s in SelectedShapes)
            {
                _shapes.Remove(s);
            }

            _shapes.TrimExcess();
        }
    }
}