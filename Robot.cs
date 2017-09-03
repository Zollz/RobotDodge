using System;
using System.Collections.Generic;
using SplashKitSDK;

public class Robot
{
    private int X { get; set; }
    private int Y { get; set; }
    private Color MainColor { get; set; }
    public Circle CollisionCircle
    {
        get
        {
            return SplashKit.CircleAt(X + (Width / 2), Y + (Height / 2), 20);
        }
    }
    private Vector2D Velocity { get; set; }

    public int Width
    {
        get { return 50; }
    }

    public int Height
    {
        get { return 50; }
    }



    public Robot(Window gameWindow, Player player)
    {
        const int Speed = 2;
        MainColor = Color.RandomRGB(200);

        if (SplashKit.Rnd() < 0.5)
        {
            Y = SplashKit.Rnd(gameWindow.Height);
            X = SplashKit.Rnd(gameWindow.Width);

            if (SplashKit.Rnd() < 0.5)

                Y = -Height;
            else
                Y = gameWindow.Height;
        }
        if (SplashKit.Rnd() < 0.5)

            X = -Width;
        else
            X = gameWindow.Width;

        Point2D fromPt = new Point2D()
        {
            X = X,
            Y = Y
        };

        Point2D toPt = new Point2D()
        {
            X = player.X,
            Y = player.Y
        };

        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));
        Velocity = SplashKit.VectorMultiply(dir, Speed);
    }

    public void Draw()
    {
        double leftX, rightX, eyeY, mouthY;
        leftX = X + 12;
        rightX = X + 27;
        eyeY = Y + 10;
        mouthY = Y + 30;
        SplashKit.FillRectangle(Color.Gray, X, Y, Width, Height);
        SplashKit.FillRectangle(MainColor, leftX, eyeY, 10, 10);
        SplashKit.FillRectangle(MainColor, rightX, eyeY, 10, 10);
        SplashKit.FillRectangle(MainColor, leftX, mouthY, 25, 10);
        SplashKit.FillRectangle(MainColor, leftX + 2, mouthY + 2, 21, 10);

    }

    public void Update()
    {

        X = Convert.ToInt32(Velocity.X) + X;
        Y = Convert.ToInt32(Velocity.Y) + Y;
    }

    public bool Offscreen(Window screen)
    {
        if (X < -Width || X > screen.Width || Y < -Height || Y > screen.Height)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}

