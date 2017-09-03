using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {

        Window gameWindow = new Window("Robot Dodge", 600, 600);
        Player player = new Player(gameWindow);
        RobotDodge game = new RobotDodge(gameWindow, player);
        Timer score = new Timer("Score");


        while ((!gameWindow.CloseRequested) && (!player.Quit))
        {
            SplashKit.ProcessEvents();
            game.HandleInput();
            game.Draw();
            game.Update();
            game.RandomRobot();
            score.Start();
            SplashKit.DrawTextOnWindow(gameWindow, "50", Color.Black, 250, 50);
        }

    }
}
