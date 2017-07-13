using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
    Window gameWindow;
	gameWindow = new Window("Robot Dodge", 700, 700);
    Bitmap _PlayerBitmap = new Bitmap("Player", "resources/images/player.png");
    gameWindow.Clear(Color.White);
    gameWindow.DrawBitmap(_PlayerBitmap, 300, 300);
    gameWindow.Refresh(60);
    SplashKit.Delay(10000);
    }
}
