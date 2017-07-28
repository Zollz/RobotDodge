using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {

        Window gameWindow = new Window("Robot Dodge", 300, 300);
        Player player = new Player(gameWindow);
        RobotDodge robot = new RobotDodge(gameWindow, player);

        while ((!gameWindow.CloseRequested) && (!player.Quit))  
        {
            SplashKit.ProcessEvents();
            robot.HandleInput();
            robot.Draw();
            robot.Update();
            robot.RandomRobot();
        }

    }
}
