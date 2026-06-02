using HopMedvedek.Data;
namespace HopMedvedek.Questions;

public class Question
{
    protected string _questionImage;
    protected string _questionText;
    protected string _questionAnswer;

    public Question()
    {
        _questionImage = HopMedvedekConstants.HOP_MEDVEDEK_DEFAULT_TEXTURE;

        _questionText = "No question";
        _questionAnswer = "No answer";
    }
    public Question(string questionImage, string questionText, string questionAnswer)
    {
        _questionImage = questionImage;

        _questionText = questionText;
        _questionAnswer = questionAnswer;
    }

    public string QuestionImage
    {
        get => _questionImage;
        set => _questionImage = value;
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
}
