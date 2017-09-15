using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

public class Bullet
{
    private Bitmap _bulletBitmap;
    private Player _Player;
    private int X { get; set; }
    private int Y { get; set; }
    private Vector2D Velocity { get; set; }

    public Bullet(Player player)
    {
        const int Speed = 5;
        _Player = player;

        Point2D fromPoint = new Point2D
        {
            X = player.X,
            Y = player.Y,
        };

        Point2D toPoint = new Point2D
        {
            X = X,
            Y = Y,
        };

        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPoint, toPoint));
        Velocity = SplashKit.VectorMultiply(dir, Speed);
    }
    public void Draw()
    {
        _bulletBitmap = new Bitmap("Bullet", "resources/images/bullet.png");
        SplashKit.DrawBitmap(_bulletBitmap, _Player.X, _Player.Y);
    }
}

