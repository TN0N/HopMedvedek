using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using Microsoft.Xna.Framework;
namespace HopMedvedek.Questions;

public class Question
{
    protected StringKey _questionText;
    protected StringKey _questionAnswer;

    protected string _questionTextString;
    protected string _questionAnswerString;

    protected Rectangle _questionImageBounds;

    public Question()
    {
        /*
        _questionText = "No question";
        _questionAnswer = "No answer";*/
    }
    public Question(StringKey questionText, StringKey questionAnswer, Rectangle? questionImageBounds)
    {

        _questionText = questionText;
        _questionAnswer = questionAnswer;

        if (questionImageBounds != null)
            _questionImageBounds = (Rectangle)questionImageBounds;
    }
    public Question(string questionText, string questionAnswer, Rectangle? questionImageBounds)
    {

        _questionTextString = questionText;
        _questionAnswerString = questionAnswer;

        if (questionImageBounds != null)
            _questionImageBounds = (Rectangle)questionImageBounds;
    }
    public StringKey QuestionText
    { 
        get => _questionText;
        set => _questionText = value;
    }
    public StringKey QuestionAnswer
    {
        get => _questionAnswer;
        set => _questionAnswer = value;
    }
    public string QuestionTextString
    {
        get => _questionTextString;
        set => _questionTextString = value;
    }
    public string QuestionAnswerString
    {
        get => _questionAnswerString;
        set => _questionAnswerString = value;
    }
    public Rectangle QuestionImageBounds
    {
        get => _questionImageBounds;
        set => _questionImageBounds = value;
    }
}
