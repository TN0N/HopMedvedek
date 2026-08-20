using Artificial.Artificial.Mirage;
using Express.Graphics;
using Express.Scene;
using HopMedvedek.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HopMedvedek.Gui.Elements;

public class SubjectMenuButton : Button
{
    protected Label _gradeLabel;
    protected Image _gradeSmiley;
    protected Image _gradeImage;
    //protected Rectangle _gradeDstRectangle;
    public SubjectMenuButton(Rectangle inputArea, Sprite backgroundImage, SpriteFont font, string text, float grade): base(inputArea, backgroundImage, font, text)
    {
        _gradeImage = new Image(new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(0, 84, 358, 154), new Vector2(179, 77)), new Rectangle(inputArea.X + 270, inputArea.Y, 90, inputArea.Height));
        Point smileySize = new Point(45, 45);
        Point smileyPosition = new Point((int)(_gradeImage.Position.X + smileySize.X/2), (int)(_gradeImage.Position.Y + smileySize.Y/2)-5);
        
        switch (grade) { 
            case var g when g >= 0.9f:
                _gradeSmiley = new Image(new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(521, 84, 15, 15), new Vector2(7, 7)), new Rectangle(smileyPosition, smileySize));
                _gradeImage.Color = Color.LimeGreen;
                
                break;
            case var g when g >= 0.8f:
                _gradeSmiley = new Image(new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(506, 84, 15, 15), new Vector2(7, 7)), new Rectangle(smileyPosition, smileySize));
                _gradeImage.Color = Color.Lime;
                break;

            case var g when g >= 0.7f:
                _gradeSmiley = new Image(new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(476, 84, 15, 15), new Vector2(7, 7)), new Rectangle(smileyPosition, smileySize));
                _gradeImage.Color = Color.Gold;
                break;
            case var g when g >= 0.6f:
                _gradeSmiley = new Image(new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(461, 84, 15, 15), new Vector2(7, 7)), new Rectangle(smileyPosition, smileySize));
                _gradeImage.Color = Color.Orange;
                break;
            default:
                _gradeSmiley = new Image(new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(446, 84, 15, 15), new Vector2(7, 7)), new Rectangle(smileyPosition, smileySize));
                _gradeImage.Color = Color.Red;
                break;

        }
        //_gradeImage.Color = Color.LimeGreen;
        _gradeImage.LayerDepth = 0.7f;
        _gradeSmiley.LayerDepth = 0.71f;
        _gradeLabel = new Label(font, grade.ToString("P0"), new Vector2(inputArea.X + 320, inputArea.Y + 40));
        _gradeLabel.VerticalAlign = VerticalAlign.Middle;
        _gradeLabel.HorizontalAlign = HorizontalAlign.Center;
        _gradeLabel.LayerDepth = 0.9f;

        
    }
    public override void AddedToScene(IScene theScene)
    {
        // Add child items to scene.
        theScene.Add(_backgroundImage);
        theScene.Add(_label);
        //theScene.Add(_gradeLabel);
        theScene.Add(_gradeSmiley);
        theScene.Add(_gradeImage);
        
    }

    public override void RemovedFromScene(IScene theScene)
    {
        // Remove child items.
        theScene.Remove(_backgroundImage);
        theScene.Remove(_label);
        //theScene.Remove(_gradeLabel);
        theScene.Remove(_gradeSmiley);
        theScene.Remove(_gradeImage);
        
    }
    public Label GradeLabel
    {
        get => _gradeLabel;
        set => _gradeLabel = value;
    }
    public Image GradeImage
    {
        get => _gradeImage;
        set => _gradeImage = value;
    }
    public Image GradeSmiley
    {
        get => _gradeSmiley;
        set => _gradeSmiley = value;
    }
    /*
    public Rectangle GradeDstRectangle
    {
        get => _gradeDstRectangle;
        set => _gradeDstRectangle = value;
    }*/
}
