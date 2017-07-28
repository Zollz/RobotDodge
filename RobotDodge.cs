using System;
using SplashKitSDK;


class RobotDodge
{
    private Player _Player;
    private Window _GameWindow;
    private Robot _TestRobot;

    public bool Quit
    {
        get { return _Player.Quit; }
    }

    public RobotDodge(Window gameWindow, Player player)
    {
        _GameWindow = gameWindow;
        _Player = player;
        _TestRobot = RandomRobot();
    }

    public void HandleInput()
    {
        _Player.HandleMethod();
        _Player.StayOnWindow(_GameWindow);
    }
    public Robot RandomRobot()
    {
       return new Robot(_GameWindow);
    }

    public void Draw()
    {
        _GameWindow.Clear(Color.White);
        _TestRobot.Draw();
        _Player.Draw();
        _GameWindow.Refresh(60);
    }
                                  
    public void Update()
    {
        if(_Player.CollidedWidth(_TestRobot))
        {   
            _TestRobot = RandomRobot();

        }
    }
}

