using System;
using SplashKitSDK;
using System.Collections.Generic;


public class Player
{

    private Bitmap _PlayerBitmap;
    public double X { get; private set; }
    public double Y { get; private set; }
    public bool Quit { get; private set; }
    const int Speed = 5;
    const int GAP = 5;
    const int Boost = 20;
   

    public int Width
    {
        get { return _PlayerBitmap.Width; }
    }

    public int Height
    {
        get { return _PlayerBitmap.Height; }
    }

    public Player(Window gameWindow)
    {
        _PlayerBitmap = new Bitmap("Player", "resources/images/Player.png");
        Quit = false;
        X = (gameWindow.Width - Width) / 2;
        Y = (gameWindow.Height - Height) / 2;
    }

  
    public void Draw()
    {
        SplashKit.DrawBitmap(_PlayerBitmap, X, Y);
    }


    public void HandleMethod()
    {
        if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            X += Speed;
        }
        if (SplashKit.KeyDown(KeyCode.RightKey) && SplashKit.KeyDown(KeyCode.LeftShiftKey))
        {
            X += Boost;
        }
        if (SplashKit.KeyDown(KeyCode.LeftKey))
        {
            X -= Speed;
        }
        if (SplashKit.KeyDown(KeyCode.LeftKey) && SplashKit.KeyDown(KeyCode.LeftShiftKey))
        {
            X -= Boost;
        }
        if (SplashKit.KeyDown(KeyCode.UpKey))
        {
            Y -= Speed;
        }
        if (SplashKit.KeyDown(KeyCode.UpKey) && SplashKit.KeyDown(KeyCode.LeftShiftKey))
        {
            Y -= Boost;
        }
        if (SplashKit.KeyDown(KeyCode.DownKey))
        {
            Y += Speed;
        }
        if (SplashKit.KeyDown(KeyCode.DownKey) && SplashKit.KeyDown(KeyCode.LeftShiftKey))
        {
            Y += Boost;
        }
        if (SplashKit.KeyTyped(KeyCode.EscapeKey))
        {
            Quit = true;
        }
    }

    public void StayOnWindow(Window gameWindow)
    {
        if (X <= GAP)
        {
            X = GAP;
        }
        if (X >= (gameWindow.Width - Width) - GAP)
        {
            X = (gameWindow.Width - Width) - GAP;
        }
        if (Y <= GAP)
        {
            Y = GAP;
        }
        if (Y >= (gameWindow.Height - Height) - GAP)
        {
            Y = (gameWindow.Height - Height) - GAP;
        }
    }

    public bool CollidedWith(Robot other)
    {
        { return _PlayerBitmap.CircleCollision(X, Y, other.CollisionCircle); }
    }
}