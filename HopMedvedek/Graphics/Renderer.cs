using Artificial.Artificial.Mirage;
using Express.Graphics;
using Express.Scene;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Rotation;
using Express.Scene.Objects.Shapes;
using HopMedvedek.Data;
using HopMedvedek.Gui.Elements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
namespace HopMedvedek.Graphics;

public class Renderer : DrawableGameComponent
{
    
    protected SpriteBatch _spriteBatch;

    protected SpriteSortMode _spriteSortMode = SpriteSortMode.FrontToBack;
    protected BlendState _blendState = null;
    protected SamplerState _samplerState = SamplerState.PointClamp;
    protected DepthStencilState _depthStencilState = null;
    protected RasterizerState _rasterizerState = null;
    protected Effect _effect = null;
    protected IScene _scene;
    protected bool _clearScreen = true;
    protected Rectangle _cameraBounds;
    //private Matrix _camera; 

    public Renderer(Game game, IScene scene) : base(game)
    {
        _scene = scene;
        //_camera = Matrix.CreateScale(new Vector3(Game.Window.ClientBounds.Width / 320f, Game.Window.ClientBounds.Height / 480f, 1));
        // _camera = _scene.CameraMatrix;
        _spriteBatch = new SpriteBatch(game.GraphicsDevice);
    }
    protected void ChangeSpriteMode(Sprite textureItem)
    {

        if (textureItem.SpriteSortMode != _spriteSortMode
         || textureItem.BlendState != _blendState
         || textureItem.SamplerState != _samplerState
         || textureItem.DepthStencilState != _depthStencilState
         || textureItem.RasterizerState != _rasterizerState
         || textureItem.Effect != _effect)
        {
            _spriteSortMode = textureItem.SpriteSortMode;
            _blendState = textureItem.BlendState;
            _samplerState = textureItem.SamplerState;
            _depthStencilState = textureItem.DepthStencilState;
            _rasterizerState = textureItem.RasterizerState;
            _effect = textureItem.Effect;
            _spriteBatch.End();
            _spriteBatch.Begin(_spriteSortMode, _blendState, _samplerState, _depthStencilState, _rasterizerState, _effect, _scene.CameraMatrix);
        }


    }
    public override void Initialize()
    {
        
        base.Initialize();
    }
    public bool ClearScreen
    {
        get => _clearScreen;
        set => _clearScreen = value;
    }

    private bool InCameraBounds(Rectangle item)
    {
        //return _cameraBounds.Intersects(item);
        return true;
    }
    public override void Draw(GameTime gameTime)
    {
        Vector2 cameraPosition = new Vector2(
            -_scene.CameraMatrix.Translation.X * ((float)Game.Window.ClientBounds.Width / HopMedvedekConstants.screenWidth),
            -_scene.CameraMatrix.Translation.Y * ((float)Game.Window.ClientBounds.Height / HopMedvedekConstants.screenHeight));

        _cameraBounds = new Rectangle(
            (int)cameraPosition.X,
            (int)cameraPosition.Y,
            GraphicsDevice.Viewport.Width+100,
            GraphicsDevice.Viewport.Height+100);

        if (_clearScreen)
            GraphicsDevice.Clear(Color.LightSkyBlue);
        int drawCount = 0;


        //System.Diagnostics.Debug.WriteLine("drawing");
        _spriteBatch.Begin(_spriteSortMode, _blendState, _samplerState, _depthStencilState, _rasterizerState, _effect, _scene.CameraMatrix);
        //_spriteBatch.Begin();
        foreach (object item in _scene)
        {
            if (item is ITextured texturedItem && item is IPosition itemPosition)
            {
                // Get items sprite to display at current time
                //System.Diagnostics.Debug.WriteLine("Drawing " + item);
                Sprite sprite = texturedItem.Sprite(gameTime);

                ChangeSpriteMode(sprite);
                SpriteEffects effect = (item is IFacing facingItem && facingItem.Facing) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

                Rectangle drawRectangle = sprite.SourceRectangle;

                if (item is ICustomDrawRect customDrawRectItem)
                    drawRectangle = new Rectangle((int)itemPosition.Position.X, (int)itemPosition.Position.Y, (int)customDrawRectItem.CustomWidth, (int)customDrawRectItem.CustomHeight);
                else if (item is IRectangleSize rectangleItem)
                    drawRectangle = new Rectangle((int)itemPosition.Position.X, (int)itemPosition.Position.Y, (int)rectangleItem.Width, (int)rectangleItem.Height);

                if (!InCameraBounds(drawRectangle))
                    continue;

                // = (item is IRectangleSize rectangleItem) ? new Rectangle((int)itemPosition.Position.X, (int)itemPosition.Position.Y, (int)rectangleItem.Width, (int)rectangleItem.Height) : sprite.SourceRectangle;

                float rotationAngle = (item is IRotatable rotatableItem) ? rotatableItem.RotationAngle : 0f;

                Vector2 origin = (item is ICustomOrigin customOriginItem) ? customOriginItem.CustomOrigin : sprite.Origin;
                //float layerDepth = (itemPosition.Position.Y + drawRectangle.Height) / (_scene.CameraMatrix.Translation.Y + Game.Window.ClientBounds.Height);

                //System.Diagnostics.Debug.WriteLine(item + " " + layerDepth);

                _spriteBatch.Draw(
                    _scene.SceneTextureData[sprite.Src],
                    drawRectangle,
                    sprite.SourceRectangle,
                    texturedItem.Color,
                    rotationAngle,
                    origin,
                    effect,
                    texturedItem.LayerDepth);
                drawCount++;
            }
            
            else if (item is Button button)
            {
                if (!InCameraBounds(button.InputArea))
                    continue;
                _spriteBatch.Draw(
                    _scene.SceneTextureData[button.BackgroundImage.Src],
                    button.InputArea,
                    button.BackgroundImage.SourceRectangle,
                    button.Color,
                    0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    button.LayerDepth);
                drawCount++;
                if (button.Label is not null)
                {
                    _spriteBatch.DrawString(
                    button.Label.Font,
                    button.Label.Text,
                    button.Label.Position,
                    button.Label.Color,
                    button.Label.Rotation,
                    button.Label.Origin,
                    button.Label.Scale,
                    SpriteEffects.None,
                    button.Label.LayerDepth);
                }
                if (item is not SubjectMenuButton subjectMenuButton)
                    continue;
                if (subjectMenuButton.GradeImage != null)
                {
                    _spriteBatch.Draw(
                    _scene.SceneTextureData[subjectMenuButton.GradeImage.Sprite(gameTime).Src],
                    new Rectangle((int)subjectMenuButton.GradeImage.Position.X, (int)subjectMenuButton.GradeImage.Position.Y, (int)subjectMenuButton.GradeImage.Width, (int)subjectMenuButton.GradeImage.Height),
                    subjectMenuButton.Sprite(gameTime).SourceRectangle,
                    subjectMenuButton.GradeImage.Color,
                    subjectMenuButton.GradeImage.RotationAngle,
                    Vector2.Zero,
                    SpriteEffects.None,
                    subjectMenuButton.GradeImage.LayerDepth);

                    _spriteBatch.DrawString(
                    subjectMenuButton.GradeLabel.Font,
                    subjectMenuButton.GradeLabel.Text,
                    subjectMenuButton.GradeLabel.Position,
                    subjectMenuButton.GradeLabel.Color,
                    subjectMenuButton.GradeLabel.Rotation,
                    subjectMenuButton.GradeLabel.Origin,
                    subjectMenuButton.GradeLabel.Scale,
                    SpriteEffects.None,
                    subjectMenuButton.GradeLabel.LayerDepth);
                }
            }
            else if (item is Label label)
            {
                //System.Diagnostics.Debug.WriteLine("Drawing label");
                if (!InCameraBounds(new Rectangle((int)label.Position.X, (int)label.Position.Y, label.Font.Texture.Width, label.Font.Texture.Height)))
                    continue;
                _spriteBatch.DrawString(
                    label.Font,
                    label.Text,
                    label.Position,
                    label.Color,
                    label.Rotation,
                    label.Origin,
                    label.Scale,
                    SpriteEffects.None,
                    label.LayerDepth);
                drawCount++;
            }
            else if (item is Slider slider)
            {
                // Track
                if (!InCameraBounds(slider.InputArea))
                    continue;
                _spriteBatch.Draw(
                    _scene.SceneTextureData[slider.TrackTexture.Src],
                    slider.InputArea,
                    slider.TrackTexture.SourceRectangle,
                    slider.Color,
                    0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    0.6f);
                // Thumb
                _spriteBatch.Draw(
                    _scene.SceneTextureData[slider.ThumbTexture.Src],
                    slider.ThumbArea,
                    slider.ThumbTexture.SourceRectangle,
                    slider.Color,
                    0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    0.7f);
                // Value Fill
                _spriteBatch.DrawString(
                    slider.ValueFill.Font,
                    slider.Value.ToString("P0"),
                    slider.ValueFill.Position,
                    slider.ValueFill.Color,
                    0f,
                    Vector2.Zero,
                    1f,
                    SpriteEffects.None,
                    slider.ValueFill.LayerDepth
                    );
                drawCount++;
            }
        }


        //System.Diagnostics.Debug.WriteLine("Drawn " + drawCount + "/" + _scene.Count() + " items");
        _spriteBatch.End();
        
    }
}
