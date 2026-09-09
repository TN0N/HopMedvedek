using HopMedvedek.Gui.Elements;
using Microsoft.Xna.Framework;
namespace HopMedvedek.GameStates.Menus;

public class Year04SubjectSelectionMenu : Menu
{
    protected Image _background;

    public Year04SubjectSelectionMenu(Game game) : base(game)
    {
        base.Initialize();
        _scene.Add(_back);
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
}
