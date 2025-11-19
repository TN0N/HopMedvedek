using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using HopMedvedek.Scene.Objects;

namespace HopMedvedek.Entities;

public class Player: GameComponent
{
    protected Bear _bear;
    protected Matrix _inverseView;
    protected float _maxSpeed;
    protected Vector2 _velocity;
    

    
    public Vector2 Velocity => _velocity;
    

    public Player(Game game, Bear bear): base(game)
    {
        _bear = bear;
        _maxSpeed = 5;
        _velocity = Vector2.Zero;
    }
    public void SetCamera(Matrix camera) {
        _inverseView = Matrix.Invert(camera);
    }
    private void ChangeState()
    {
        if (_velocity.Y < 0)
            _bear.State = Bear.StateEnum.JumpUp;
        else if (_velocity.Y > 0)
            _bear.State = Bear.StateEnum.JumpDown;
        else if (_velocity.X < 0)
        {
            _bear.Facing = Bear.FacingEnum.Left;
            _bear.State = Bear.StateEnum.Walk;
        }
        else if (_velocity.X > 0)
        {
            _bear.Facing = Bear.FacingEnum.Right;
            _bear.State = Bear.StateEnum.Walk;
        }
        else
            _bear.State = Bear.StateEnum.Idle;

    }
    public override void Update(GameTime gameTime)
    {
        _velocity = Vector2.Zero;
        if (Keyboard.GetState().IsKeyDown(Keys.W))
            _velocity.Y -= 1;
        if (Keyboard.GetState().IsKeyDown(Keys.S))
            _velocity.Y += 1;
        if (Keyboard.GetState().IsKeyDown(Keys.A))
            _velocity.X -= 1;
        if (Keyboard.GetState().IsKeyDown(Keys.D))
            _velocity.X += 1;

        _velocity.Normalize();
        if (!float.IsNaN(_velocity.X) && !float.IsNaN(_velocity.Y))
            _bear.Position += _velocity * _maxSpeed;

        ChangeState();
        
            /*
            Vector2 mouseInScene = Vector2.
                Transform(
                    Mouse.GetState().Position.ToVector2(), 
                    _inverseView
                    );
            _bear.Position.X = mouseInScene.X;
            */

                /*
        _bear.Position.X += newVelocity.X * _maxVelocity;
        _bear.Position.Y += newVelocity.Y * _maxVelocity;
        System.Diagnostics.Debug.WriteLine(newVelocity);
                */
    }
}
