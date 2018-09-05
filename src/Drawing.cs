using System;
using System.Linq;
using System.IO;
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

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);

            try
            {
                writer.WriteLine(Background.ToArgb());
                writer.WriteLine(ShapeCount);
    
                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            finally
            {
                writer.Close();
            }
        }

        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            Background = Color.FromArgb(reader.ReadInteger());
            int count = reader.ReadInteger();
            string kind;
            Shape s;

            try
            {
                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();
    
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new Rectangle();
                            break;
    
                        case "Circle":
                            s = new Circle();
                            break;
    
                        case "Line":
                            s = new Line();
                            break;
    
                        default:
                            throw new InvalidDataException("Unknown shape kind: " + kind);
                    }
    
                    s.LoadFrom(reader);
                    AddShape(s);
                }
            }
            finally
            {
                reader.Close();
            }
        }
    }
}