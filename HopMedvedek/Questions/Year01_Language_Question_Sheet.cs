using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

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
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_APPLE,
                new Rectangle(0 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Baby
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BABY,
                new Rectangle(1 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Ball
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BALL,
                new Rectangle(2 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Banana
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BANANA,
                new Rectangle(3 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Bed
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BED,
                new Rectangle(4 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Bee
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BEE,
                new Rectangle(5 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Bird
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BIRD,
                new Rectangle(6 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Boat
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BOAT,
                new Rectangle(7 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Book
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BOOK,
                new Rectangle(8 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Boy
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BOY,
                new Rectangle(9 * _questionImageWidth, 0 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Bread
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BREAD,
                new Rectangle(0 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Castle
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CASTLE,
                new Rectangle(1 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Bus
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BUS,
                new Rectangle(2 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Cake
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CAKE,
                new Rectangle(3 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Car
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CAR,
                new Rectangle(4 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Cat
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CAT,
                new Rectangle(5 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Chair
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CHAIR,
                new Rectangle(6 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Chicken
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CHICKEN,
                new Rectangle(7 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Spoon
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SPOON,
                new Rectangle(8 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Clock
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CLOCK,
                new Rectangle(9 * _questionImageWidth, 1 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Coat
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_COAT,
                new Rectangle(0 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Cow
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_COW,
                new Rectangle(1 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Cup
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CUP,
                new Rectangle(2 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Dad
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DAD,
                new Rectangle(3 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Dog
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DOG,
                new Rectangle(4 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Door
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DOOR,
                new Rectangle(5 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Duck
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DUCK,
                new Rectangle(6 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Egg
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_EGG,
                new Rectangle(7 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Eye
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_EYE,
                new Rectangle(8 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Farm
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FARM,
                new Rectangle(9 * _questionImageWidth, 2 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Fish
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FISH,
                new Rectangle(0 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Flower
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FLOWER,
                new Rectangle(1 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Foot
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FOOT,
                new Rectangle(2 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Clown
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CLOWN,
                new Rectangle(3 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Frog
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FROG,
                new Rectangle(4 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Game
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_GAME,
                new Rectangle(5 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Garden
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_GARDEN,
                new Rectangle(6 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Girl
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_GIRL,
                new Rectangle(7 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Hand
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HAND,
                new Rectangle(8 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Hat
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HAT,
                new Rectangle(9 * _questionImageWidth, 3 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Sock
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SOCK,
                new Rectangle(0 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Hill
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HILL,
                new Rectangle(1 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Horse
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HORSE,
                new Rectangle(2 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // House
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HOUSE,
                new Rectangle(3 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Ice cream
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_ICE_CREAM,
                new Rectangle(4 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Juice
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_JUICE,
                new Rectangle(5 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Key
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_KEY,
                new Rectangle(6 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // King
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_KING,
                new Rectangle(7 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Kite
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_KITE,
                new Rectangle(8 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Leg
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_LEG,
                new Rectangle(9 * _questionImageWidth, 4 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Lion
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_LION,
                new Rectangle(0 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MAN
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MAN,
                new Rectangle(1 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MILK
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MILK,
                new Rectangle(2 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MUM
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MUM,
                new Rectangle(3 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MONKEY
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MONKEY,
                new Rectangle(4 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MOON
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOON,
                new Rectangle(5 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // Magnet
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MAGNET,
                new Rectangle(6 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MOUSE
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOUSE,
                new Rectangle(7 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // NEST
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NEST,
                new Rectangle(8 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // NOSE
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NOSE,
                new Rectangle(9 * _questionImageWidth, 5 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // PARK
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PARK,
                new Rectangle(0 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // PEN
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PEN,
                new Rectangle(1 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // PENCIL
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PENCIL,
                new Rectangle(2 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // PIG
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PIG,
                new Rectangle(3 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // PIZZA
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PIZZA,
                new Rectangle(4 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // PLANT
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PLANT,
                new Rectangle(5 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // QUEEN
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_QUEEN,
                new Rectangle(6 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // RABBIT
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_RABBIT,
                new Rectangle(7 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // RAIN
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_RAIN,
                new Rectangle(8 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // RIVER
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_RIVER,
                new Rectangle(9 * _questionImageWidth, 6 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // ROAD
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_ROAD,
                new Rectangle(0 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MUSHROOM
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MUSHROOM,
                new Rectangle(1 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // SHEEP
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SHEEP,
                new Rectangle(2 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // SHOE
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SHOE,
                new Rectangle(3 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // SHELL
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SHELL,
                new Rectangle(4 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // CLOUD
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CLOUD,
                new Rectangle(5 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // SNAKE
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SNAKE,
                new Rectangle(6 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // SNOWFLAKE
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SNOWFLAKE,
                new Rectangle(7 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // STAR
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_STAR,
                new Rectangle(8 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // SUN
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SUN,
                new Rectangle(9 * _questionImageWidth, 7 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // TABLE
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TABLE,
                new Rectangle(0 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MAP
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MAP,
                new Rectangle(1 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // BEAR
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BEAR,
                new Rectangle(2 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // TIGER
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TIGER,
                new Rectangle(3 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // TRAIN
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TRAIN,
                new Rectangle(4 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // TREE
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TREE,
                new Rectangle(5 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // TRUCK
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TRUCK,
                new Rectangle(6 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // WATER
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WATER,
                new Rectangle(7 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // WHALE
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WHALE,
                new Rectangle(8 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // WINDOW
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WINDOW,
                new Rectangle(9 * _questionImageWidth, 8 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // WOMAN
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WOMAN,
                new Rectangle(0 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // WORM
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WORM,
                new Rectangle(1 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // ZEBRA
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_ZEBRA,
                new Rectangle(2 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // MOUNTAIN
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOUNTAIN,
                new Rectangle(3 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // DRUM
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DRUM,
                new Rectangle(4 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // HEART
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HEART,
                new Rectangle(5 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // CUPBOARD
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CUPBOARD,
                new Rectangle(6 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // NET
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NET,
                new Rectangle(7 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // PEACH
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PEACH,
                new Rectangle(8 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
            // CARD
            new Question(
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,
                StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CARD,
                new Rectangle(9 * _questionImageWidth, 9 * _questionImageHeight, _questionImageWidth, _questionImageHeight)
            ),
        };
    }
}
