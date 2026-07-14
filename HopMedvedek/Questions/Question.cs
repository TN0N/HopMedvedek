using HopMedvedek.Data;
using Microsoft.Xna.Framework;
namespace HopMedvedek.Questions;

public class Question
{
    protected string _questionText;
    protected string _questionAnswer;

    protected Rectangle _questionImageBounds;

    public Question()
    {
        _questionText = "No question";
        _questionAnswer = "No answer";
    }
    public Question(string questionText, string questionAnswer, Rectangle? questionImageBounds)
    {

        _questionText = questionText;
        _questionAnswer = questionAnswer;

        if (questionImageBounds != null)
            _questionImageBounds = (Rectangle)questionImageBounds;
    }
    public string QuestionText
    { 
        get => _questionText;
        set => _questionText = value;
    }
    public string QuestionAnswer
    {
        get => _questionAnswer;
        set => _questionAnswer = value;
    }
    public Rectangle QuestionImageBounds
    {
        get => _questionImageBounds;
        set => _questionImageBounds = value;
    }
}
