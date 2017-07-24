using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
               
       Window gameWindow = new Window("Robot Dodge", 300, 300);
       Player player = new Player(gameWindow);


        while (! gameWindow.CloseRequested)
        {
            SplashKit.ProcessEvents();
            gameWindow.Clear(Color.White);
            player.Draw();
            gameWindow.Refresh(60);
            player.HandleMethod();
            player.StayOnWindow(gameWindow);
        }

    }
}
