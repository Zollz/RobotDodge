using System;
using SplashKitSDK;

public class Player
{
	private Bitmap _PlayerBitmap;

	public double X 
	{ 
		get; private set;
	}

	public double Y
	{
		get; private set;
	}

	public int Width
    {
		get { return _PlayerBitmap.Width; }
    }

	public Player(double X, double Y)	
	{
		Bitmap _PlayerBitmap = new Bitmap("Player", "resources/images/player.png");
	    Window gameWindow;
        gameWindow = new Window("Robot Dodge", 700, 700);
		X = (gameWindow.Width - Width) / 2;
	}

	public void Draw()
	{
		SplashKit.DrawBitmap("Player", X, Y);
	}
}