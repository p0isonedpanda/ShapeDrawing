using System;
using SwinGameSDK;

namespace ShapeDrawing
{
    public class GameMain
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Drawing myDrawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;

            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0,0);

                if (SwinGame.KeyTyped(KeyCode.vk_r))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SwinGame.KeyTyped(KeyCode.vk_c))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SwinGame.KeyTyped(KeyCode.vk_l))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        newShape = new Rectangle();
                    }
                    else if (kindToAdd == ShapeKind.Circle)
                    {
                        newShape = new Circle();
                    }
                    else
                    {
                        newShape = new Line();
                    }
                
                    newShape.X = SwinGame.MouseX();
                    newShape.Y = SwinGame.MouseY();
                    myDrawing.AddShape(newShape);
                }
                
                if (SwinGame.KeyTyped(KeyCode.vk_SPACE))
                {
                    myDrawing.Background = SwinGame.RandomRGBColor(255);
                }

                if (SwinGame.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SwinGame.MousePosition());
                }

                if (SwinGame.KeyTyped(KeyCode.vk_DELETE))
                {
                    myDrawing.RemoveSelected();
                }

                if (SwinGame.KeyTyped(KeyCode.vk_s))
                {
                    myDrawing.Save("./ShapeDrawing.txt");
                }

                if (SwinGame.KeyTyped(KeyCode.vk_o))
                {
                    try
                    {
                        myDrawing.Load("./ShapeDrawing.txt");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }

                myDrawing.Draw();

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}