using System;
using System.Collections.Generic;
using SplashKitSDK;


public class RobotDodge
{
    private Player _Player;
    private Window _GameWindow;
    private Bitmap Life;
    private double Score;
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

        for (int i = 1; i <= Lives; i++)
        {
            SplashKit.DrawBitmap(Life, 600 - (i * 50), 50);
        }
       
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

                if(Lives == 0)
                {
                    SplashKit.CloseCurrentWindow();
                }
            }
        }

        foreach(Robot robot in _removedRobots)
        {
            _Robot.Remove(robot);
        }
    }
}

