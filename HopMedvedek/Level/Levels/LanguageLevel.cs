using Microsoft.Xna.Framework;

namespace HopMedvedek.Level.Levels;

public class LanguageLevel : LevelBase
{
    public LanguageLevel(Game game) : base(game)
    {
        int RightX = Game.Window.ClientBounds.Width;
        int BottomY = Game.Window.ClientBounds.Height;

        int midX = Game.Window.ClientBounds.Width / 2;
        int midY = Game.Window.ClientBounds.Height / 2;

        
        
        _ground.Position = new Vector2(midX, BottomY - _ground.Height / 2);
        _tree.Position = new Vector2(_ground.Position.X, _ground.Position.Y - _ground.Height/1.75f);
        _bear.Position = _tree.Position;

    }
}
