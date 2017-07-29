using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {

        Window gameWindow = new Window("Robot Dodge", 300, 300);
        Player player = new Player(gameWindow);
        RobotDodge game = new RobotDodge(gameWindow, player);

        while ((!gameWindow.CloseRequested) && (!player.Quit))  
        {
            SplashKit.ProcessEvents();
            game.HandleInput();
            game.Draw();
            game.Update();
        }

    }
}
