using System;
using SwinGameSDK;

namespace ShapeDrawing
{
    public class GameMain
    {
        public static void Main()
        {
            Drawing myDrawing = new Drawing();

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

                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    myDrawing.AddShape(new Shape(Color.Purple, SwinGame.MouseX() - 25, SwinGame.MouseY() - 25, 50, 50));
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

                myDrawing.Draw();

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}