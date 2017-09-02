using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;


public class Bullet
{
    private Bitmap _bullet;
    public double _x, _y;
_
    public Bullet(double x, double y, double angle)
    {
        _bullet = new Bitmap("bullet", '/resources/images/bullet.png');
    }

    public void Update()
    {
        const int bulletSpeed = 20;
        Vector2D = new Vector2D();

    }
}

