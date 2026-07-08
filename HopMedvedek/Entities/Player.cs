using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using HopMedvedek.Scene.Objects;
using Express.Scene.Objects;
using HopMedvedek.Data;
using HopMedvedek.Audio;

namespace HopMedvedek.Entities;

public class Player: GameComponent
{
    protected Bear _bear;
    protected Matrix _inverseView;
    protected Lifetime _stateLifeTime;
    protected Vector2 _throwMouseClickPosition;

    protected bool _startedGame = false;
    protected bool _canThrowPinecone = true;

    public Player(Game game, Bear bear): base(game)
    {
        _bear = bear;
        _bear.Velocity = Vector2.Zero;
        _bear.Acceleration = Vector2.Zero;
    }
    public void SetCamera(Matrix camera) {
        _inverseView = Matrix.Invert(camera);
    }
    private void ChangeState(GameTime gameTime)
    {
        _bear.Grounded = true;

        if (_bear.State == BearState.BearDazed)
        {

            if (_stateLifeTime == null)
            {
                _stateLifeTime = new Lifetime(gameTime.TotalGameTime.TotalMilliseconds, HopMedvedekConstants.HOP_MEDVEDEK_BEAR_DAZED_ANIMATION_DURATION / 1000);
                
            }
            //else
            //    System.Diagnostics.Debug.WriteLine(_stateLifeTime.IsAlive + "    " + _stateLifeTime.Progress);
            _stateLifeTime.Update(gameTime);
            if (!_stateLifeTime.IsAlive)
            {
                _stateLifeTime = null;
                _bear.State = BearState.BearIdle;
            }
            else
            {
                _bear.State = BearState.BearDazed;
            }
            return;
        }
        if (_bear.State == BearState.BearWalkThrow)
        {
            if (_stateLifeTime == null)
                _stateLifeTime = new Lifetime(gameTime.TotalGameTime.TotalMilliseconds, HopMedvedekConstants.HOP_MEDVEDEK_BEAR_THROW_ANIMATION_DURATION/ 1000);

            _stateLifeTime.Update(gameTime);
            if (!_stateLifeTime.IsAlive)
            {
                _stateLifeTime = null;
                _bear.State = BearState.BearIdle;
                _canThrowPinecone = true;
            }
            else
            {
                if (_stateLifeTime.Percentage >= 0.5f && _canThrowPinecone)
                {
                    SoundEngine.Play(SoundEffectType.BearThrow, null, null, Options.Options.Current.GameVolume);
                    _bear.ThrowPinecone(_throwMouseClickPosition);
                    _canThrowPinecone = false;
                }
                    
                _bear.State = BearState.BearWalkThrow;
            }
            return;
        }
        if (_bear.State == BearState.BearJumpThrow)
        {
            if (_stateLifeTime == null)
                _stateLifeTime = new Lifetime(gameTime.TotalGameTime.TotalMilliseconds, HopMedvedekConstants.HOP_MEDVEDEK_BEAR_THROW_ANIMATION_DURATION/ 1000);

            _stateLifeTime.Update(gameTime);
            if (!_stateLifeTime.IsAlive)
            {
                _stateLifeTime = null;
                _canThrowPinecone = true;
                _bear.State = BearState.BearIdle;
            }
            else
            {
                if (_stateLifeTime.Percentage >= 0.5f && _canThrowPinecone && _bear.PlayerPinecones > 0)
                {
                    SoundEngine.Play(SoundEffectType.BearThrow, null, null, Options.Options.Current.GameVolume);
                    _bear.ThrowPinecone(_throwMouseClickPosition);
                    _canThrowPinecone = false;
                }

                _bear.State = BearState.BearJumpThrow;
            }
            return;
        }
        if (_bear.Velocity.Y < -17)
        {
            _bear.State = BearState.BearJumpUp;
            //_bear.Grounded = false;
        }
        else if (_bear.Velocity.Y > 17)
        {
            _bear.State = BearState.BearJumpDown;
            //_bear.Grounded = false;
        }
        else if (_bear.Velocity.X < -2)
            _bear.State = BearState.BearWalk;
        else if (_bear.Velocity.X > 2)
            _bear.State = BearState.BearWalk;
        else
            _bear.State = BearState.BearIdle;

    }
    public override void Update(GameTime gameTime)
    {


        //PrintHelper.Print(_bear.Velocity);

        if (Keyboard.GetState().IsKeyDown(Keys.Space) && !_bear.Jumping)
            _startedGame = true;


        if (_bear.Grounded && !_bear.Jumping && _bear.State != BearState.BearDazed && _startedGame)
        {
            SoundEngine.Play(SoundEffectType.BearJump, null, null, Options.Options.Current.GameVolume);
            _bear.Velocity.Y -= HopMedvedekConstants.HOP_MEDVEDEK_BEAR_JUMP_VELOCITY;
            _bear.Jumping = true;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.A) && _bear.Acceleration.X >= 0)
            _bear.Acceleration.X -= HopMedvedekConstants.HOP_MEDVEDEK_BEAR_MOVEMENT_ACCELERATION;
            
        if (Keyboard.GetState().IsKeyDown(Keys.D) && _bear.Acceleration.X <= 0)
            _bear.Acceleration.X += HopMedvedekConstants.HOP_MEDVEDEK_BEAR_MOVEMENT_ACCELERATION;
        if (Keyboard.GetState().IsKeyUp(Keys.A) && _bear.Acceleration.X < 0)
            _bear.Acceleration.X += HopMedvedekConstants.HOP_MEDVEDEK_BEAR_MOVEMENT_ACCELERATION;
        if (Keyboard.GetState().IsKeyUp(Keys.D) && _bear.Acceleration.X > 0)
            _bear.Acceleration.X -= HopMedvedekConstants.HOP_MEDVEDEK_BEAR_MOVEMENT_ACCELERATION;

        ChangeState(gameTime);

        if (Keyboard.GetState().IsKeyDown(Keys.F) && _bear.State != BearState.BearDazed)
            _bear.State = BearState.BearDazed;
        if (Mouse.GetState().LeftButton == ButtonState.Pressed && (_bear.State != BearState.BearDazed || _bear.State == BearState.BearWalkThrow || _bear.State == BearState.BearJumpThrow))
        { 
            _throwMouseClickPosition = Mouse.GetState().Position.ToVector2();

            //_throwMouseClickPosition.Y -= _bear.Position.Y;
            _throwMouseClickPosition = Vector2.Transform(_throwMouseClickPosition, Matrix.Invert(_bear.Level.Scene.CameraMatrix));

            
            //System.Diagnostics.Debug.WriteLine(_throwMouseClickPosition);

            if (_bear.Jumping)
                _bear.State = BearState.BearJumpThrow;
            else
                _bear.State = BearState.BearWalkThrow;
        }
            
        //if (Mouse.GetState().RightButton == ButtonState.Pressed)
        //    _bear.State = BearState.BearJumpThrow;

       

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
