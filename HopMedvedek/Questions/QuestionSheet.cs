using System.Collections.Generic;

namespace HopMedvedek.Questions;

public abstract class QuestionSheet
{
    protected List<Question> _questions;

    public List<Question> Questions {
        get => _questions;
        set => _questions = value;
    }
}

