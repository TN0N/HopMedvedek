using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace HopMedvedek00;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _playerTexture;
    private Texture2D _crowTexture;
    private Texture2D _owlTexture;
    private Texture2D _natureTexture;
    private Texture2D _skyTexture;

    private Texture2D _objectsTexture;

    private Dictionary<string, Rectangle> _spriteRegions;
    private Vector2 _position = new Vector2(0, 0);

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _graphics.PreferredBackBufferWidth = 320;
        _graphics.PreferredBackBufferHeight = 576;
        _graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _playerTexture = Content.Load<Texture2D>("bear");
        _crowTexture = Content.Load<Texture2D>("crow");
        _owlTexture = Content.Load<Texture2D>("owl");
        _natureTexture = Content.Load<Texture2D>("nature");
        _objectsTexture = Content.Load<Texture2D>("objects");
        _skyTexture = Content.Load<Texture2D>("sky");

        _spriteRegions = new Dictionary<string, Rectangle>
        {
            {"player", new Rectangle(0,0,36,42)},
            {"crow", new Rectangle(0,0,53,42)},
            {"owl", new Rectangle(0,0,60,61)},
            {"tree_base", new Rectangle(28,11,47,26)},
            {"tree_trunk", new Rectangle(0,0,28,37)},
            {"tree_branch_end", new Rectangle(28,2,17,9)},
            {"tree_branch_start", new Rectangle(45,4,4,7)},
            {"tree_leaf_00", new Rectangle(75,14,35,23)},
            {"tree_leaf_01", new Rectangle(110,15,27,22)},
            {"tree_leaf_02", new Rectangle(137,16,29,21)},
            {"tree_leaf_03", new Rectangle(166,9,37,28)},
            {"object_bed", new Rectangle(0,0,211,211)},
            {"object_bookshelf", new Rectangle(211,34,177,177)},
            {"object_pots", new Rectangle(388,17,126,90)},
            {"object_chair", new Rectangle(388,106,105,105)},
            {"object_plate", new Rectangle(493,136,28,28)},
            {"object_book", new Rectangle(493,164,47,47)},
            {"sky", new Rectangle(0,0,320,576)},
            {"grass", new Rectangle(0,37,320,16)},
        };
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();
        _spriteBatch.Draw(_skyTexture, _position, _spriteRegions["sky"], Color.White);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(0, 544), _spriteRegions["grass"], Color.White, 0, new Vector2(0,0), new Vector2(2f, 2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(133, 514), _spriteRegions["tree_base"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(144, 470), _spriteRegions["tree_trunk"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(144, 426), _spriteRegions["tree_trunk"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(144, 382), _spriteRegions["tree_trunk"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(144, 338), _spriteRegions["tree_trunk"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(144, 294), _spriteRegions["tree_trunk"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(144, 250), _spriteRegions["tree_trunk"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(144, 206), _spriteRegions["tree_trunk"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(144, 162), _spriteRegions["tree_trunk"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(144, 118), _spriteRegions["tree_trunk"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(144, 74), _spriteRegions["tree_trunk"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(144, 30), _spriteRegions["tree_trunk"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(144, -14), _spriteRegions["tree_trunk"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);

        _spriteBatch.Draw(_natureTexture, _position + new Vector2(140, 233), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(137, 233), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(134, 233), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(131, 233), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(129, 233), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(126, 233), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(123, 233), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(103, 230), _spriteRegions["tree_branch_end"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(73, 220), _spriteRegions["tree_leaf_03"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);

        _spriteBatch.Draw(_natureTexture, _position + new Vector2(140, 233), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(137, 273), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(134, 273), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(131, 273), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(129, 273), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(126, 273), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(123, 273), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(103, 270), _spriteRegions["tree_branch_end"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(73, 260), _spriteRegions["tree_leaf_03"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);

        _spriteBatch.Draw(_natureTexture, _position + new Vector2(140, 133), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(137, 133), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(134, 133), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(131, 133), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(129, 133), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(126, 133), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(123, 133), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(103, 130), _spriteRegions["tree_branch_end"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(73, 120), _spriteRegions["tree_leaf_03"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);

        _spriteBatch.Draw(_natureTexture, _position + new Vector2(140, 33), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(137, 33), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(134, 33), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(131, 33), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(129, 33), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(126, 33), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(123, 33), _spriteRegions["tree_branch_start"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(103, 30), _spriteRegions["tree_branch_end"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.Draw(_natureTexture, _position + new Vector2(73, 20), _spriteRegions["tree_leaf_03"], Color.White, 0, new Vector2(0, 0), new Vector2(1.2f, 1.2f), SpriteEffects.None, 0);
        _spriteBatch.End();
        /*
        // Draw different sprites
        //_spriteBatch.Draw(_skyTexture, _position, _spriteRegions["sky"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(0, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(16, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(32, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(48, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(64, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(80, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(96, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(112, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(128, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(144, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(160, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(176, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(192, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(208, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(224, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(240, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(256, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(272, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(288, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(304, 544), _spriteRegions["grass"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(136, 518), _spriteRegions["treeBase"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(145, 444), _spriteRegions["treeTrunk"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(145, 481), _spriteRegions["treeTrunk"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(145, 407), _spriteRegions["treeTrunk"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(145, 370), _spriteRegions["treeTrunk"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(145, 333), _spriteRegions["treeTrunk"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(145, 296), _spriteRegions["treeTrunk"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(145, 259), _spriteRegions["treeTrunk"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(145, 222), _spriteRegions["treeTrunk"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(145, 185), _spriteRegions["treeTrunk"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(145, 148), _spriteRegions["treeTrunk"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(145, 111), _spriteRegions["treeTrunk"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(145, 74), _spriteRegions["treeTrunk"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(145, 37), _spriteRegions["treeTrunk"], Color.White);
        _spriteBatch.Draw(_treeTexture, _position + new Vector2(145, 0), _spriteRegions["treeTrunk"], Color.White);
        _spriteBatch.Draw(_playerTexture, _position + new Vector2(180, 507), _spriteRegions["player"], Color.White);
        _spriteBatch.Draw(_crowTexture, _position + new Vector2(180, 267), _spriteRegions["crow"], Color.White);
        _spriteBatch.Draw(_crowTexture, _position + new Vector2(80, 207), _spriteRegions["crow"], Color.White);
        _spriteBatch.Draw(_crowTexture, _position + new Vector2(200, 100), _spriteRegions["crow"], Color.White);
        _spriteBatch.Draw(_owlTexture, _position + new Vector2(32, 500), _spriteRegions["owl"], Color.White);
        //_spriteBatch.Draw(_atlasTexture, _position + new Vector2(50, 0), _spriteRegions["enemy"], Color.White);
        */

        base.Draw(gameTime);
    }
}
