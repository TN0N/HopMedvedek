using System.Collections.Generic;

namespace HopMedvedek.Questions;

public abstract class QuestionSheet
{
    protected List<Question> _questions;
    protected string _questionSheetTextures;
    public string QuestionSheetTextures
    {
        get => _questionSheetTextures;
    }
    public List<Question> Questions {
        get => _questions;
        set => _questions = value;
    }
}

