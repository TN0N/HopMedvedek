using Express.Graphics;
using HopMedvedek.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HopMedvedek.Graphics;

public class GameRenderer : DrawableGameComponent
{
    protected ContentManager _content;
    protected Texture2D _levelBackground;

    protected string[] _resourses = new string[(int)ResourceStrings.LAST];


    protected SpriteBatch _spriteBatch;


    public GameRenderer(Game game, Level level, Camera camera) : base(game)
    {

        _resourses[(int)ResourceStrings.SKY] = "sky";

        _content = game.Content;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _levelBackground = _content.Load<Texture2D>(_resourses[(int)ResourceStrings.SKY]);
    }
    public override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin(SpriteSortMode.Texture);
        _spriteBatch.Draw(_levelBackground, new Vector2(0, 0), Color.White);
        _spriteBatch.End();
    }
    protected override void UnloadContent()
    {
        _content.Unload();
    }
}
