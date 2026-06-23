using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopMedvedek.Questions;

public class Year01_Language_Question_Sheet : QuestionSheet
{
    public Year01_Language_Question_Sheet()
    {
        _questions = new List<Question>()
        {
            new Question(
                HopMedvedekConstants.HOP_MEDVEDEK_DEFAULT_TEXTURE, 
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language], "TEMP_TEXT_REMOVE_OR_REPLACE"
                ),
            new Question(
                HopMedvedekConstants.HOP_MEDVEDEK_FATHER_TEXTURE,
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FATHER][Options.Options.Current.Language]
            ),
            new Question(
                HopMedvedekConstants.HOP_MEDVEDEK_MOTHER_TEXTURE,
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FATHER][Options.Options.Current.Language]
            ),

        };
    }
}
