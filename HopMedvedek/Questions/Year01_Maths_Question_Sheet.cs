using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using System;
using System.Collections.Generic;

namespace HopMedvedek.Questions;

public class Year01_Maths_Question_Sheet : QuestionSheet
{
    private int _questionImageWidth = 256;
    private int _questionImageHeight = 384;
    private int _maxNumber = 19;
    public void GenerateQuestions()
    {
        int additionA, additionB;
        additionA = Random.Shared.Next(1, _maxNumber);
        additionB = Random.Shared.Next(1, _maxNumber - additionA);
        int additionAnswer = additionA + additionB;

        string additionQuestionString = string.Format(
            Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_MATHS_QUESTION_ADDITION][Options.Options.Current.Language],
            additionA,
            additionB);
        string additionAnswerString = "" + additionAnswer;




        int subtractionAnswer = -1;
        int subtractionA = 0, subtractionB = 0;
        while (subtractionAnswer < 0 || subtractionAnswer == additionAnswer)
        {
            subtractionA = Random.Shared.Next(1, _maxNumber);
            subtractionB = Random.Shared.Next(1, _maxNumber - subtractionA);

            if (subtractionA < subtractionB)
            {
                int temp = subtractionA;
                subtractionA = subtractionB;
                subtractionB = temp;
            }

            subtractionAnswer = subtractionA - subtractionB;
        }
        string subtractionQuestionString = string.Format(
            Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_MATHS_QUESTION_SUBTRACTION][Options.Options.Current.Language],
            subtractionA,
            subtractionB);
        string subtractionAnswerString = "" + subtractionAnswer;

        _questions = new List<Question>()
        {
            // Addition
            new Question(
                additionQuestionString,
                additionAnswerString,
                //new Rectangle(0 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
                null
            ),
            // Subtraction
            new Question(
                subtractionQuestionString,
                subtractionAnswerString,
                //new Rectangle(1 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
                null
            ),
        };
    }
    public Year01_Maths_Question_Sheet()
    {
        _questionSheetTextures = HopMedvedekConstants.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTIONS_TEXTURES_01;
        GenerateQuestions();
    }
}
