using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using HopMedvedek.Scene.Objects;
using Express.Physics;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Composites;

namespace HopMedvedek.Entities;

public class Player: GameComponent
{
    protected Bear _bear;
    protected Matrix _inverseView;

    public Player(Game game, Bear bear): base(game)
    {
        _bear = bear;
        _bear.Velocity = Vector2.Zero;
    }
    public void SetCamera(Matrix camera) {
        _inverseView = Matrix.Invert(camera);
    }
    private void ChangeState()
    {
        if (_bear.Velocity.X < 0)
        {
            _bear.Facing = Bear.FacingEnum.Left;
        }
        if (_bear.Velocity.X > 0)
            _bear.Facing = Bear.FacingEnum.Right;


        if (_bear.Velocity.Y < 0)
        {
            _bear.State = Bear.StateEnum.JumpUp;
            _bear.Grounded = false;
        }
        else if (_bear.Velocity.Y > 0)
        {
            _bear.State = Bear.StateEnum.JumpDown;
            _bear.Grounded = false;
        }
        else if (_bear.Velocity.X < 0)
            _bear.State = Bear.StateEnum.Walk;
        else if (_bear.Velocity.X > 0)
            _bear.State = Bear.StateEnum.Walk;
        else
            _bear.State = Bear.StateEnum.Idle;

    }
    public override void Update(GameTime gameTime)
    {
        /*_bear.Velocity = Vector2.Zero;*/;
        bool Areleased = Keyboard.GetState().IsKeyUp(Keys.A);
        bool Dreleased = Keyboard.GetState().IsKeyUp(Keys.D);

        if (Keyboard.GetState().IsKeyDown(Keys.Space) && _bear.Grounded)
            _bear.Velocity.Y -= 500;
        if (Keyboard.GetState().IsKeyDown(Keys.A) && _bear.Velocity.X >= 0)
            _bear.Velocity.X -= 180;
        if (Keyboard.GetState().IsKeyDown(Keys.D) && _bear.Velocity.X <= 0)
            _bear.Velocity.X += 180;
        if (Keyboard.GetState().IsKeyUp(Keys.A) && _bear.Velocity.X < 0)
            _bear.Velocity.X += 180;
        if (Keyboard.GetState().IsKeyUp(Keys.D) && _bear.Velocity.X > 0)
            _bear.Velocity.X -= 180;



        /*
        _bear.Velocity.Normalize();
        if (float.IsNaN(_bear.Velocity.X)) 
            _bear.Velocity.X = 0;
        if (float.IsNaN(_bear.Velocity.Y))
            _bear.Velocity.Y = 0;
        _bear.Velocity *= _bear.MaxSpeed;
        */
        ChangeState();
    }

}
