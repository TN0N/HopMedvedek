using HopMedvedek.Gui.Elements;
using Microsoft.Xna.Framework;

namespace HopMedvedek.GameStates.Menus;

public class Year03SubjectSelectionMenu : Menu
{
    protected Image _background;

    public Year03SubjectSelectionMenu(Game game) : base(game)
    {
        base.Initialize();

        _scene.Add(_back);
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
}
