using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopMedvedek.Questions;

public class Year01_Language_Question_Sheet : QuestionSheet
{
    private int _questionImageWidth = 256;
    private int _questionImageHeight = 384;

    public Year01_Language_Question_Sheet()
    {
        _questionSheetTextures = HopMedvedekConstants.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTIONS_TEXTURES_01;
        _questions = new List<Question>()
        {
            // Apple
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_APPLE][Options.Options.Current.Language],
                new Rectangle(0 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Baby
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BABY][Options.Options.Current.Language],
                new Rectangle(1 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Ball
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BALL][Options.Options.Current.Language],
                new Rectangle(2 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Banana
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BANANA][Options.Options.Current.Language],
                new Rectangle(3 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Bed
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BED][Options.Options.Current.Language],
                new Rectangle(4 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Bee
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BEE][Options.Options.Current.Language],
                new Rectangle(5 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Bird
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BIRD][Options.Options.Current.Language],
                new Rectangle(6 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Boat
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BOAT][Options.Options.Current.Language],
                new Rectangle(7 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Book
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BOOK][Options.Options.Current.Language],
                new Rectangle(8 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Boy
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BOY][Options.Options.Current.Language],
                new Rectangle(9 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Bread
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BREAD][Options.Options.Current.Language],
                new Rectangle(0 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Castle
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CASTLE][Options.Options.Current.Language],
                new Rectangle(1 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Bus
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BUS][Options.Options.Current.Language],
                new Rectangle(2 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Cake
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CAKE][Options.Options.Current.Language],
                new Rectangle(3 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Car
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CAR][Options.Options.Current.Language],
                new Rectangle(4 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Cat
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CAT][Options.Options.Current.Language],
                new Rectangle(5 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Chair
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CHAIR][Options.Options.Current.Language],
                new Rectangle(6 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Chicken
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CHICKEN][Options.Options.Current.Language],
                new Rectangle(7 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Spoon
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SPOON][Options.Options.Current.Language],
                new Rectangle(8 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Clock
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CLOCK][Options.Options.Current.Language],
                new Rectangle(9 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Coat
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_COAT][Options.Options.Current.Language],
                new Rectangle(0 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Cow
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_COW][Options.Options.Current.Language],
                new Rectangle(1 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Cup
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CUP][Options.Options.Current.Language],
                new Rectangle(2 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Dad
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DAD][Options.Options.Current.Language],
                new Rectangle(3 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Dog
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DOG][Options.Options.Current.Language],
                new Rectangle(4 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Door
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DOOR][Options.Options.Current.Language],
                new Rectangle(5 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Duck
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DUCK][Options.Options.Current.Language],
                new Rectangle(6 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Egg
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_EGG][Options.Options.Current.Language],
                new Rectangle(7 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Eye
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_EYE][Options.Options.Current.Language],
                new Rectangle(8 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Farm
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FARM][Options.Options.Current.Language],
                new Rectangle(9 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Fish
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FISH][Options.Options.Current.Language],
                new Rectangle(0 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Flower
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FLOWER][Options.Options.Current.Language],
                new Rectangle(1 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Foot
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FOOT][Options.Options.Current.Language],
                new Rectangle(2 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Clown
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CLOWN][Options.Options.Current.Language],
                new Rectangle(3 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Frog
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FROG][Options.Options.Current.Language],
                new Rectangle(4 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Game
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_GAME][Options.Options.Current.Language],
                new Rectangle(5 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Garden
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_GARDEN][Options.Options.Current.Language],
                new Rectangle(6 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Girl
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_GIRL][Options.Options.Current.Language],
                new Rectangle(7 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Hand
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HAND][Options.Options.Current.Language],
                new Rectangle(8 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Hat
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HAT][Options.Options.Current.Language],
                new Rectangle(9 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Sock
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SOCK][Options.Options.Current.Language],
                new Rectangle(0 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Hill
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HILL][Options.Options.Current.Language],
                new Rectangle(1 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Horse
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HORSE][Options.Options.Current.Language],
                new Rectangle(2 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // House
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HOUSE][Options.Options.Current.Language],
                new Rectangle(3 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Ice cream
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_ICE_CREAM][Options.Options.Current.Language],
                new Rectangle(4 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Juice
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_JUICE][Options.Options.Current.Language],
                new Rectangle(5 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Key
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_KEY][Options.Options.Current.Language],
                new Rectangle(6 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // King
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_KING][Options.Options.Current.Language],
                new Rectangle(7 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Kite
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_KITE][Options.Options.Current.Language],
                new Rectangle(8 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Leg
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_LEG][Options.Options.Current.Language],
                new Rectangle(9 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Lion
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_LION][Options.Options.Current.Language],
                new Rectangle(0 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MAN
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MAN][Options.Options.Current.Language],
                new Rectangle(1 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MILK
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MILK][Options.Options.Current.Language],
                new Rectangle(2 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MUM
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MUM][Options.Options.Current.Language],
                new Rectangle(3 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MONKEY
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MONKEY][Options.Options.Current.Language],
                new Rectangle(4 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MOON
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOON][Options.Options.Current.Language],
                new Rectangle(5 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Magnet
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MAGNET][Options.Options.Current.Language],
                new Rectangle(6 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MOUSE
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOUSE][Options.Options.Current.Language],
                new Rectangle(7 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // NEST
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NEST][Options.Options.Current.Language],
                new Rectangle(8 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // NOSE
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NOSE][Options.Options.Current.Language],
                new Rectangle(9 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // PARK
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PARK][Options.Options.Current.Language],
                new Rectangle(0 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // PEN
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PEN][Options.Options.Current.Language],
                new Rectangle(1 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // PENCIL
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PENCIL][Options.Options.Current.Language],
                new Rectangle(2 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // PIG
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PIG][Options.Options.Current.Language],
                new Rectangle(3 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // PIZZA
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PIZZA][Options.Options.Current.Language],
                new Rectangle(4 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // PLANT
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PLANT][Options.Options.Current.Language],
                new Rectangle(5 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // QUEEN
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_QUEEN][Options.Options.Current.Language],
                new Rectangle(6 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // RABBIT
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_RABBIT][Options.Options.Current.Language],
                new Rectangle(7 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // RAIN
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_RAIN][Options.Options.Current.Language],
                new Rectangle(8 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // RIVER
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_RIVER][Options.Options.Current.Language],
                new Rectangle(9 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // ROAD
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_ROAD][Options.Options.Current.Language],
                new Rectangle(0 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MUSHROOM
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MUSHROOM][Options.Options.Current.Language],
                new Rectangle(1 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // SHEEP
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SHEEP][Options.Options.Current.Language],
                new Rectangle(2 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // SHOE
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SHOE][Options.Options.Current.Language],
                new Rectangle(3 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // SHELL
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SHELL][Options.Options.Current.Language],
                new Rectangle(4 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // CLOUD
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CLOUD][Options.Options.Current.Language],
                new Rectangle(5 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // SNAKE
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SNAKE][Options.Options.Current.Language],
                new Rectangle(6 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // SNOWFLAKE
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SNOWFLAKE][Options.Options.Current.Language],
                new Rectangle(7 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // STAR
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_STAR][Options.Options.Current.Language],
                new Rectangle(8 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // SUN
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SUN][Options.Options.Current.Language],
                new Rectangle(9 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // TABLE
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TABLE][Options.Options.Current.Language],
                new Rectangle(0 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MAP
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MAP][Options.Options.Current.Language],
                new Rectangle(1 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // BEAR
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BEAR][Options.Options.Current.Language],
                new Rectangle(2 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // TIGER
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TIGER][Options.Options.Current.Language],
                new Rectangle(3 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // TRAIN
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TRAIN][Options.Options.Current.Language],
                new Rectangle(4 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // TREE
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TREE][Options.Options.Current.Language],
                new Rectangle(5 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // TRUCK
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TRUCK][Options.Options.Current.Language],
                new Rectangle(6 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // WATER
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WATER][Options.Options.Current.Language],
                new Rectangle(7 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // WHALE
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WHALE][Options.Options.Current.Language],
                new Rectangle(8 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // WINDOW
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WINDOW][Options.Options.Current.Language],
                new Rectangle(9 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // WOMAN
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WOMAN][Options.Options.Current.Language],
                new Rectangle(0 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // WORM
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WORM][Options.Options.Current.Language],
                new Rectangle(1 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // ZEBRA
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_ZEBRA][Options.Options.Current.Language],
                new Rectangle(2 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MOUNTAIN
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOUNTAIN][Options.Options.Current.Language],
                new Rectangle(3 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // DRUM
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DRUM][Options.Options.Current.Language],
                new Rectangle(4 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // HEART
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HEART][Options.Options.Current.Language],
                new Rectangle(5 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // CUPBOARD
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CUPBOARD][Options.Options.Current.Language],
                new Rectangle(6 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // NET
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NET][Options.Options.Current.Language],
                new Rectangle(7 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // PEACH
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PEACH][Options.Options.Current.Language],
                new Rectangle(8 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // CARD
            new Question(
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE][Options.Options.Current.Language],
                Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CARD][Options.Options.Current.Language],
                new Rectangle(9 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
        };
    }
}
