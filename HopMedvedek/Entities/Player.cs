using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using HopMedvedek.Scene.Objects;
using Express.Physics;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Composites;
using Artificial;

namespace HopMedvedek.Entities;

public class Player: GameComponent
{
    protected Bear _bear;
    protected Matrix _inverseView;

    public Player(Game game, Bear bear): base(game)
    {
        _bear = bear;
        _bear.Velocity = Vector2.Zero;
        _bear.Acceleration = Vector2.Zero;
    }
    public void SetCamera(Matrix camera) {
        _inverseView = Matrix.Invert(camera);
    }
    private void ChangeState()
    {
        _bear.Grounded = true;
        if (_bear.Velocity.X < 0)
        {
            _bear.Facing = Bear.FacingEnum.Left;
        }
        if (_bear.Velocity.X > 0)
            _bear.Facing = Bear.FacingEnum.Right;


        if (_bear.Velocity.Y < -17)
        {
            _bear.State = Bear.StateEnum.JumpUp;
            //_bear.Grounded = false;
        }
        else if (_bear.Velocity.Y > 17)
        {
            _bear.State = Bear.StateEnum.JumpDown;
            //_bear.Grounded = false;
        }
        else if (_bear.Velocity.X < -2)
            _bear.State = Bear.StateEnum.Walk;
        else if (_bear.Velocity.X > 2)
            _bear.State = Bear.StateEnum.Walk;
        else
            _bear.State = Bear.StateEnum.Idle;

    }
    public override void Update(GameTime gameTime)
    {
        ChangeState();

        PrintHelper.Print(_bear.Velocity);
        if (Keyboard.GetState().IsKeyDown(Keys.Space) && !_bear.Jumping)
        {
            _bear.Velocity.Y -= 500;
            _bear.Jumping = true;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.A) && _bear.Acceleration.X >= 0)
            _bear.Acceleration.X -= 2000;
        if (Keyboard.GetState().IsKeyDown(Keys.D) && _bear.Acceleration.X <= 0)
            _bear.Acceleration.X += 2000;
        if (Keyboard.GetState().IsKeyUp(Keys.A) && _bear.Acceleration.X < 0)
            _bear.Acceleration.X += 2000;
        if (Keyboard.GetState().IsKeyUp(Keys.D) && _bear.Acceleration.X > 0)
            _bear.Acceleration.X -= 2000;

        if (Keyboard.GetState().IsKeyDown(Keys.F))
            _bear.State = Bear.StateEnum.Dazed;
        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            _bear.State = Bear.StateEnum.WalkThrow;
        if (Mouse.GetState().RightButton == ButtonState.Pressed)
            _bear.State = Bear.StateEnum.JumpThrow;



        /*
        _bear.Velocity.Normalize();
        if (float.IsNaN(_bear.Velocity.X)) 
            _bear.Velocity.X = 0;
        if (float.IsNaN(_bear.Velocity.Y))
            _bear.Velocity.Y = 0;
        _bear.Velocity *= _bear.MaxSpeed;
        */
        
    }

}
