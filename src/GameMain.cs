using System;
using SwinGameSDK;

namespace ShapeDrawing
{
    public class GameMain
    {
        public static void Main()
        {
            Shape myShape = new Shape();

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
                
                // Move the shape to the location of the mouse when clicking the left mouse button
                if (SwinGame.MouseDown(MouseButton.LeftButton))
                {
                    myShape.X = SwinGame.MouseX();
                    myShape.Y = SwinGame.MouseY();
                }

                // Change the colour of the shape if the mouse is inside the shape and we are pressing space
                if (SwinGame.KeyReleased(KeyCode.vk_SPACE) && myShape.IsAt(SwinGame.MousePosition()))
                {
                    myShape.ShapeColor = SwinGame.RandomRGBColor(255);
                }

                myShape.Draw();
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}