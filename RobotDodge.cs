using System;
using System.Collections.Generic;
using SplashKitSDK;


public class RobotDodge
{
    private Player _Player;
    private Window _GameWindow;
    private Bitmap Life;
    public double Score;
    public int Lives = 5;
    private static List<Robot> _Robot = new List<Robot>();

    public bool Quit
    {
        get { return _Player.Quit; }
    }

    public RobotDodge(Window gameWindow, Player player)
    {
        _GameWindow = gameWindow;
        _Player = player;
        Life = new Bitmap("Life", "resources/images/heart.png");
    }

    public void HandleInput()
    {
        _Player.HandleMethod();
        _Player.StayOnWindow(_GameWindow);
    }
    public Robot RandomRobot()
    {
        return new Robot(_GameWindow, _Player);
    }

    public void Draw()
    {
        _GameWindow.Clear(Color.White);

        foreach(Robot robot in _Robot)
        {
            robot.Draw();
        }
        if (Lives == 5)
        {
            SplashKit.DrawBitmap(Life, 550, 50);
            SplashKit.DrawBitmap(Life, 500, 50);
            SplashKit.DrawBitmap(Life, 450, 50);
            SplashKit.DrawBitmap(Life, 400, 50);
            SplashKit.DrawBitmap(Life, 350, 50);
        }
        if (Lives == 4)
        {
            SplashKit.DrawBitmap(Life, 550, 50);
            SplashKit.DrawBitmap(Life, 500, 50);
            SplashKit.DrawBitmap(Life, 450, 50);
            SplashKit.DrawBitmap(Life, 400, 50);
        }
        if (Lives ==3)
        {
            SplashKit.DrawBitmap(Life, 550, 50);
            SplashKit.DrawBitmap(Life, 500, 50);
            SplashKit.DrawBitmap(Life, 450, 50);
        }
        if (Lives == 2)
        {
            SplashKit.DrawBitmap(Life, 550, 50);
            SplashKit.DrawBitmap(Life, 500, 50);
        }
        if (Lives == 1)
        {
            SplashKit.DrawBitmap(Life, 550, 50);
        }
        Timer score = new Timer("Score");
        score.Start();
        Score = score.Ticks / 1000;
        SplashKit.DrawTextOnWindow(_GameWindow, Score.ToString(), Color.Black, 100, 50);
        _Player.Draw();

        
        _GameWindow.Refresh(60);
    }

    public void Update()
    {
        foreach (Robot robot in _Robot)
        {
            robot.Update();
        }

        if(SplashKit.Rnd() < 0.05)
        {
            _Robot.Add(RandomRobot());
        }
        CheckCollisions();
    }


    private void CheckCollisions()  
    {
        List<Robot> _removedRobots = new List<Robot>(); 

        
        foreach(Robot robot in _Robot)
        {
            if (_Player.CollidedWith(robot) || robot.Offscreen(_GameWindow))
            {
                _removedRobots.Add(robot);
              
            }

            if(_Player.CollidedWith(robot))
            {
                Lives = Lives - 1;
            }
        }

        foreach(Robot robot in _removedRobots)
        {
            _Robot.Remove(robot);
        }
    }
}

