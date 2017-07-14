using System;
using SplashKitSDK;

public class Player
{
    private Bitmap _PlayerBitmap;
    public double _x { get; private set; }
    public double _y { get; private set; }


    public int Width
    {
        get
        {
            return _PlayerBitmap.Width;
        }
    }

    public Player(double x, double y)
    {
        _PlayerBitmap = new Bitmap("Player", "player.png");
        _x = x;
        _y = y;
    }                    

    public void Draw()
    {
        SplashKit.DrawBitmap(_PlayerBitmap, _x, _y);
    }
}