using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Player newPlayer = new Player(50, 50);
        Window gameWindow = new Window("Robot Dodge", 200, 200);

        
        gameWindow.Clear(Color.White);
        newPlayer.Draw();
        gameWindow.Refresh(60);
        SplashKit.Delay(5000);
    }
}
