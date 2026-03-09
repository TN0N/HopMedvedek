using Microsoft.Xna.Framework;

namespace HopMedvedek.Level.Levels;

public class LanguageLevel : LevelBase
{
    public LanguageLevel(Game game) : base(game)
    {
        _bearSpawn = new Vector2(0, 0);
        _treeBaseSpawn = new Vector2(0, 0);
    }
}
